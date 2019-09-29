using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml;
using VDownloader;

namespace AkiraVoid
{
    /// <summary>
    /// 这个是为了方便地使用 iconfont 定义的
    /// 控件模板中应该将要用到 iconfont 的元素的相应属性绑定到这个属性上
    /// </summary>
    public class IconName : DependencyObject
    {


        public static String GetName(DependencyObject obj)
        {
            return (String)obj.GetValue(NameProperty);
        }

        public static void SetName(DependencyObject obj, String value)
        {
            obj.SetValue(NameProperty, value);
        }

        public static readonly DependencyProperty NameProperty =
            DependencyProperty.RegisterAttached("Name", typeof(String), typeof(IconName), new PropertyMetadata(""));


    }
    /// <summary>
    /// 通过该属性设定 ProcessBar 的 Value
    /// </summary>
    public class ProgressBarData : DependencyObject
    {
        public static int GetData(DependencyObject obj)
        {
            return (int)obj.GetValue(DataProperty);
        }

        public static void SetData(DependencyObject obj, int value)
        {
            obj.SetValue(DataProperty, value);
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.RegisterAttached("Data", typeof(int), typeof(ProgressBarData), new PropertyMetadata(0));
    }
    /// <summary>
    /// DownloadList 中的 Item 的 Button 的相关属性
    /// </summary>
    public class DownloadListButtonProperty : DependencyObject
    {
        #region PauseButtonIsEnabled 属性
        public static Boolean GetPauseButtonIsEnabled(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(PauseButtonIsEnabledProperty);
        }

        public static void SetPauseButtonIsEnabled(DependencyObject obj, Boolean value)
        {
            obj.SetValue(PauseButtonIsEnabledProperty, value);
        }

        public static readonly DependencyProperty PauseButtonIsEnabledProperty =
            DependencyProperty.RegisterAttached("PauseButtonIsEnabled", typeof(Boolean), typeof(DownloadListButtonProperty), new PropertyMetadata(true));
        #endregion
        #region StartButtonIsEnabled 属性


        public static Boolean GetStartButtonIsEnabled(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(StartButtonIsEnabledProperty);
        }

        public static void SetStartButtonIsEnabled(DependencyObject obj, Boolean value)
        {
            obj.SetValue(StartButtonIsEnabledProperty, value);
        }

        public static readonly DependencyProperty StartButtonIsEnabledProperty =
            DependencyProperty.RegisterAttached("StartButtonIsEnabled", typeof(Boolean), typeof(DownloadListButtonProperty), new PropertyMetadata(true));


        #endregion
        #region StopButtonIsEnabled 属性


        public static Boolean GetStopButtonIsEnabled(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(StopButtonIsEnabledProperty);
        }

        public static void SetStopButtonIsEnabled(DependencyObject obj, Boolean value)
        {
            obj.SetValue(StopButtonIsEnabledProperty, value);
        }

        public static readonly DependencyProperty StopButtonIsEnabledProperty =
            DependencyProperty.RegisterAttached("StopButtonIsEnabled", typeof(Boolean), typeof(DownloadListButtonProperty), new PropertyMetadata(true));


        #endregion
        #region DeleteButtonIsEnabled 属性


        public static Boolean GetDeleteButtonIsEnabled(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(DeleteButtonIsEnabledProperty);
        }

        public static void SetDeleteButtonIsEnabled(DependencyObject obj, Boolean value)
        {
            obj.SetValue(DeleteButtonIsEnabledProperty, value);
        }

        public static readonly DependencyProperty DeleteButtonIsEnabledProperty =
            DependencyProperty.RegisterAttached("DeleteButtonIsEnabled", typeof(Boolean), typeof(DownloadListButtonProperty), new PropertyMetadata(true));


        #endregion
    }
    /// <summary>
    /// DownloadList 中每个 Item 的属性
    /// </summary>
    public class DownloadListItemProperty : DependencyObject
    {
        #region ItemID 属性


        public static String GetItemID(DependencyObject obj)
        {
            return (String)obj.GetValue(ItemIDProperty);
        }

        public static void SetItemID(DependencyObject obj, String value)
        {
            obj.SetValue(ItemIDProperty, value);
        }

        public static readonly DependencyProperty ItemIDProperty =
            DependencyProperty.RegisterAttached("ItemID", typeof(String), typeof(DownloadListItemProperty), new PropertyMetadata(""));


        #endregion
        #region ProjectName 属性


        public static String GetProjectName(DependencyObject obj)
        {
            return (String)obj.GetValue(ProjectNameProperty);
        }

        public static void SetProjectName(DependencyObject obj, String value)
        {
            obj.SetValue(ProjectNameProperty, value);
        }

        public static readonly DependencyProperty ProjectNameProperty =
            DependencyProperty.RegisterAttached("ProjectName", typeof(String), typeof(DownloadListItemProperty), new PropertyMetadata("Unknown"));


        #endregion
        #region Date 属性

        //按理来说这里应该使用 Date 返回类型，但该属性只用于显示，因此使用更方便的 String 类型
        public static String GetDate(DependencyObject obj)
        {
            return (String)obj.GetValue(DateProperty);
        }

        public static void SetDate(DependencyObject obj, String value)
        {
            obj.SetValue(DateProperty, value);
        }

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.RegisterAttached("Date", typeof(String), typeof(DownloadListItemProperty), new PropertyMetadata("1977-06-08"));


        #endregion
    }
    /// <summary>
    /// 控件模板的事件处理程序
    /// </summary>
    public partial class EventHandler
    {
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            CacheFileEditor editor = new CacheFileEditor("test", 100, 1, false);
            editor.Edit();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Config.CreateCacheFile("test", "Test Task", (UInt64)10000);
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            CacheFileEditor editor = new CacheFileEditor("test", 0, 0, false);
            editor.Edit();
            // 删除已下载文件
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // 这个按钮只在任务停止时有用，删除任务文件
            Config.DeleteCacheFile("test");
        }
    }
}
