using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

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
    /// DownloadList 中的 PauseButton 的相关属性
    /// </summary>
    public class PauseButtonProperty : DependencyObject
    {
        #region IsEnabled 属性
        public static Boolean GetIsEnabled(DependencyObject obj)
        {
            return (Boolean)obj.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(DependencyObject obj, Boolean value)
        {
            obj.SetValue(IsEnabledProperty, value);
        }

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached("IsEnabled", typeof(Boolean), typeof(PauseButtonProperty), new PropertyMetadata(true));
        #endregion
    }
    /// <summary>
    /// 控件模板的事件处理程序
    /// </summary>
    public partial class EventHandler
    {
        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hi");
        }
    }
}
