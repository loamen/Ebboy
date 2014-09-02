using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ebboy.Core.Extensions
{
    /// <summary>
    /// 枚举扩展
    /// </summary>
    public static class EnumExtension
    {
        /// <summary>
        /// 获取枚举项的Description特性的描述文字
        /// </summary>
        /// <param name="enumeration"> </param>
        /// <returns> </returns>
        /// 创 建 者：Loamen.com
        public static string ToDescription(this Enum enumeration)
        {
            Type enumType = enumeration.GetType();
            MemberInfo[] members = enumType.GetMember(enumeration.CastTo<string>());
            if (members.Length > 0)
            {
                return members[0].ToDescription();
            }
            return enumeration.CastTo<string>();
        }

        /// <summary>
        /// 获取枚举的所有值及描述
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="enumType"></param>
        /// <returns></returns>
        /// 创 建 者：Loamen.com
        public static Dictionary<TKey, string> ToDescription<TKey>(this Type enumType)
        {
            if (!enumType.IsEnum) throw new ArgumentException("enumType");
            var dic = new Dictionary<TKey, string>();
            var values = Enum.GetValues(enumType);

            foreach (var value in values)
            {
                TKey itemKey = (TKey)value;
                string itemValue = ToDescription((Enum)value);
                dic.Add(itemKey, itemValue);
            }

            return dic;
        }
    }
}
