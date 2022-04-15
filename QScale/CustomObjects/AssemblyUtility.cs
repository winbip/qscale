using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace CustomObjects
{
    public class AssemblyUtility
    {
     
        public static string GetAssName()
        {
            return Assembly.GetExecutingAssembly().FullName.ToString();
        }

        /// <summary>
        /// Return current assembly
        /// </summary>
        /// <returns></returns>
        public static Assembly GetAssembly()
        {
            return Assembly.GetExecutingAssembly();
        }

       
        public static List<string> GetObjectList()
        {
            Assembly CurrentAssembly=Assembly.GetExecutingAssembly();
            List<string> ObjectList=new List<string>();

            foreach (Type type in CurrentAssembly.GetTypes())
            {
                ObjectList.Add(type.Name.ToString());
            }
            return ObjectList;
        }

    }
}
