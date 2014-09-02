using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Helpers
{

    [DataContract]
    public abstract class EnumHelper
    {
        /// <summary>
        /// 获取枚举值(string)集合ValueToList
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static List<string> GetValueList(Type type)
        {
            List<string> T = new List<string>();
            if (type.IsEnum)
            {
                foreach (FieldInfo fi in type.GetFields(BindingFlags.Static | BindingFlags.Public))
                {
                    string value = ((int)System.Enum.Parse(type, fi.Name, true)).ToString();
                    T.Add(value);
                }
            }
            return T;
        }

        /// <summary>
        /// 获取枚举成员值(string)和描述说明
        /// </summary>
        /// <param name="type">枚举类型</param>
        /// <returns>字典Dictionary(string值,string描述)</returns>
        /// 创 建 者：Loamen.com
        public static Dictionary<string, string> GetValueDescription(Type type)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            if (type.IsEnum)
            {
                foreach (FieldInfo fi in type.GetFields(BindingFlags.Static | BindingFlags.Public))
                {
                    string value = ((int)System.Enum.Parse(type, fi.Name, true)).ToString();
                    string description = string.Empty;
                    Object[] att = fi.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (att == null || att.Length == 0)
                    {
                        description = fi.Name;
                    }
                    else
                    {
                        DescriptionAttribute da = att[0] as DescriptionAttribute;
                        description = da.Description;
                    }
                    dic.Add(value, description);
                }
            }
            return dic;
        }
    }
}
