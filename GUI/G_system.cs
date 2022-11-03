using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    class G_system
    {
        public static void ShowForm(string link, string solutionname)
        {
            Type type = Type.GetType(solutionname.Trim() +"." + link.Trim());
            object ob;
            ob = Activator.CreateInstance(type);
            Window win = (Window)ob;
            win.Show();
        }
        public static UserControl Show(string link, string solutionname)
        {
            Type type = Type.GetType(solutionname.Trim() + "." + link.Trim());
            object ob;
            ob = Activator.CreateInstance(type);
            UserControl us = (UserControl)ob;
            return us;
        }

    }
}
