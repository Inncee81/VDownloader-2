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
        public static void WriteCacheFile(String Id)
        {
            
        }
        public static XmlDocument CreateXmlFile(String fileName,String rootNodeName,String path = @"\",String fileType = ".xml")
        {
            String storagePath = Directory.GetCurrentDirectory() + path;
            String fullPath = storagePath + @"\" + fileName + fileType;
            DIRECTORYDETECT:
            if (Directory.Exists(storagePath))
            {
                XmlDocument doc = new XmlDocument();
                XmlNode header = doc.CreateXmlDeclaration("1.0","utf-8",null);
                doc.AppendChild(header);
                if(rootNodeName != null && rootNodeName.ToString() != "")
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
    }
}
