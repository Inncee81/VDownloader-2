using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using Microsoft.Toolkit.Wpf;

namespace VDownloader
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RedirectTo(Pages.DownloadingPage);//初始化页面
        }
        #region 页面跳转的实现及目录按钮的 Click 事件
        /// <summary>
        /// 在这里写出程序的所有页面
        /// 页面的名称应与其 .xaml 文件的名称一致
        /// </summary>
        public enum Pages
        {
            DownloadingPage,//这是默认页面
            DownloadedPage,
            AddTaskPage,
            OpenTorrentPage,
            SettingsPage,
        }

        /// <summary>
        /// 跳转到指定页面
        /// </summary>
        /// <param name="page">页面的名称</param>
        public void RedirectTo(Pages page)
        {
            switch (page)
            {
                case Pages.DownloadingPage:
                    ContentHolder.Content = new Frame() { Content = new DownloadingPage() };
                    break;
                case Pages.DownloadedPage:
                    ContentHolder.Content = new Frame() { Content = new DownloadedPage() };
                    break;
                case Pages.AddTaskPage:
                    ContentHolder.Content = new Frame() { Content = new AddTaskPage() };
                    break;
                case Pages.OpenTorrentPage:
                    ContentHolder.Content = new Frame() { Content = new OpenTorrentPage() };
                    break;
                case Pages.SettingsPage:
                    ContentHolder.Content = new Frame() { Content = new SettingsPage() };
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 跳转到 DownloadingPage.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadingMenuButton_Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(Pages.DownloadingPage);
        }
        /// <summary>
        /// 跳转到 DownloadedPage.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadedMenuButton_Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(Pages.DownloadedPage);
        }
        /// <summary>
        /// 跳转到 AddTaskPage.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTaskMenuButton_Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(Pages.AddTaskPage);
        }
        /// <summary>
        /// 跳转到 OpenTorrentPage.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenTorrentMenuButton_Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(Pages.OpenTorrentPage);
        }
        /// <summary>
        /// 跳转到 SettingsPage.xaml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SettingMenuButton_Click(object sender, RoutedEventArgs e)
        {
            RedirectTo(Pages.SettingsPage);
        }
        #endregion
    }
}

