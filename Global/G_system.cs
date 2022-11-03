using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Global
{
    public class G_system
    {
        public static void ShowWindow(String Link,String SolotionName,out Object ob)
        {
            try
            {
                Type type = Type.GetType(SolotionName.Trim() + "." + Link);
                ob = Activator.CreateInstance(type);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
