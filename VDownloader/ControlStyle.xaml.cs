using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AkiraVoid
{
    /// <summary>
    /// 这个是为了方便地使用iconfont定义的
    /// 控件模板中应该将要用到iconfont的元素的相应属性绑定到这个属性上
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

        // Using a DependencyProperty as the backing store for Name.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameProperty =
            DependencyProperty.RegisterAttached("Name", typeof(String), typeof(IconName), new PropertyMetadata(""));


    }
}
