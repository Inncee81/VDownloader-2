using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;

namespace VDownloader
{
    public class Downloader
    {
        public String DownloadUrl { get; set; } = "";
        public Boolean Download(DownloadMethod method)
        {
            switch (method)
            {
                case DownloadMethod.ByUrl:
                    return DownloadByUrl(DownloadUrl);
                default:
                    return false;
            }
        }
        public void Pause()
        {

        }
        public void Stop()
        {

        }
        public void Delete()
        {

        }
        public override String ToString()
        {
            return base.ToString();
        }
        public enum DownloadMethod
        {
            ByUrl,
        }
        private Boolean DownloadByUrl(String url)
        {
            if (url != null && url != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public static class Config
    {
        public static void CreateCacheFile(String id, String itemName, UInt64 totalSize)
        {
            String storagePath = Directory.GetCurrentDirectory() + @"\cache\";
            XmlDocument doc = new XmlDocument();
        CREATEFILE:
            if (Directory.Exists(storagePath))
            {
                /*
                 <?xml version="1.0" encoding="utf-8" ?>
                 <Item ProjectName="Name" Id="id" CreateDate="2019-06-03">
                   <Process>22</Process>
                   <DownloadState>on/off/waiting</DownloadState>
                   <Size>
                     <Total>24458894(Byte)</Total>
                     <Done>23334343(Byte)</Done>
                   </Size>
                 </Item>
                */
                String fullPath = storagePath + id + ".vdlcache";
                XmlNode header = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(header);
                XmlElement root = doc.CreateElement("Item");
                root.SetAttribute("ProjectName", itemName);
                root.SetAttribute("Id", id);
                DateTime date = DateTime.Now;
                root.SetAttribute("CreateDate", date.ToString("yyyy-MM-dd"));
                XmlElement process = doc.CreateElement("Process");
                process.InnerText = "0";
                root.AppendChild(process);
                XmlElement downloadState = doc.CreateElement("DownloadState");
                downloadState.InnerText = "on";
                root.AppendChild(downloadState);
                XmlElement size = doc.CreateElement("Size");
                XmlElement totalSizeNode = doc.CreateElement("Total");
                totalSizeNode.InnerText = totalSize.ToString();
                size.AppendChild(totalSizeNode);
                XmlElement doneSize = doc.CreateElement("Done");
                doneSize.InnerText = "0";
                size.AppendChild(doneSize);
                root.AppendChild(size);
                doc.AppendChild(root);
                doc.Save(fullPath);
            }
            else
            {
                Directory.CreateDirectory(storagePath);
                goto CREATEFILE;
            }
        }
        public static void CreateCacheFile(String id, String name, Int32 processVal)
        {

        }
        public static void CreateCacheFile(String id, String name, DateTime date, Int32 processVal)
        {

        }
        public static XmlDocument CreateXmlFile(String fileName, String rootNodeName, String path = @"\", String fileType = ".xml")
        {
            String storagePath = Directory.GetCurrentDirectory() + path;
            String fullPath = storagePath + @"\" + fileName + fileType;
        DIRECTORYDETECT:
            if (Directory.Exists(storagePath))
            {
                XmlDocument doc = new XmlDocument();
                XmlNode header = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(header);
                if (rootNodeName != null && rootNodeName.ToString() != "")
                {
                    XmlElement root = doc.CreateElement(rootNodeName);
                    doc.AppendChild(root);
                    doc.Save(fullPath);
                    return doc;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Directory.CreateDirectory(storagePath);
                goto DIRECTORYDETECT;
            }
        }
        public static void DeleteCacheFile(String id)
        {
            String path = Directory.GetCurrentDirectory() + @"\cache\" + id + ".vdlcache";
            try
            {
                File.Delete(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "VDownloader Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
        }
    }
    public class CacheFileEditor
    {
        private static String Id { get; set; } = "";
        private static String NewName { get; set; } = "";
        private static UInt64 NewSize { get; set; } = 0;
        private static UInt64 DownloadedSize { get; set; } = 0;
        private static Int32 NewProcess
        {
            get
            {
                return _NewProcess;
            }
            set
            {
                if (value >= 0 && value <= 100)
                {
                    _NewProcess = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("NewProcess", value, "This value must be 0-100.");
                }
            }
        }
        private static Int32 _NewProcess = 0;
        private static Boolean NewDownloadState { get; set; } = true;
        /// <summary>
        /// 初始化一个 CacheFileEditor
        /// </summary>
        /// <param name="downloadedSize">已下载的大小</param>
        /// <param name="id">要修改的缓存文件id</param>
        /// <param name="newName">更改项目名称</param>
        /// <param name="newSize">更改项目总大小</param>
        /// <param name="newProcess">完成的进度</param>
        /// <param name="newDownloadState">更改下载状态</param>
        public CacheFileEditor(String id, UInt64 downloadedSize, Int32 newProcess, Boolean newDownloadState = true, String newName = "", UInt64 newSize = 0)
        {
            Id = id;
            NewName = newName;
            NewSize = newSize;
            DownloadedSize = downloadedSize;
            NewProcess = newProcess;
            NewDownloadState = newDownloadState;
        }
        /// <summary>
        /// 初始化一个 CacheFileEditor
        /// </summary>
        /// <param name="id">要修改的缓存文件id</param>
        /// <param name="downloadedSize">已下载的大小</param>
        /// <param name="newProcess">完成的进度</param>
        /// <param name="newDownloadState">更改下载状态</param>
        public CacheFileEditor(String id, UInt64 downloadedSize, Int32 newProcess, Boolean newDownloadState)
        {
            DownloadedSize = downloadedSize;
            Id = id;
            NewProcess = newProcess;
            NewDownloadState = newDownloadState;
        }
        public void Edit()
        {
            // 判断需要更改的内容
            // Done, Process 和 DownloadState 必须更改
            String path = Directory.GetCurrentDirectory() + @"\cache\" + Id + ".vdlcache";
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "VDownloader Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                XmlNode ds = doc.SelectSingleNode("Item/DownloadState");
                ds.InnerText = NewDownloadState == true ? "on" : "off";
                XmlNode done = doc.SelectSingleNode("Item/Size/Done");
                done.InnerText = DownloadedSize.ToString();
                XmlNode proc = doc.SelectSingleNode("Item/Process");
                proc.InnerText = NewProcess.ToString();
                if (NewName != "")
                {
                    XmlElement item = (XmlElement)doc.SelectSingleNode("Item");
                    item.SetAttribute("ProjectName", NewName);
                }
                if (NewSize != 0)
                {
                    XmlNode size = doc.SelectSingleNode("Item/Size/Total");
                    size.InnerText = NewSize.ToString();
                }
                doc.Save(path);
            }
            catch (Exception)
            {
                MessageBox.Show("The config is wrong.", "VDownloader Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

        }
    }
}
