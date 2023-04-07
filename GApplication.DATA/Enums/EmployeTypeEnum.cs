using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GApplication.DATA.Enums
{
    public enum EmployeTypeEnum
    {
        [Description("Part Time")]
        PartTime,
        [Description("Full Time")]
        FullTime,
        [Description("Free Lancer")]
        FreeLancer
    }
    public static class getEnumName
    {
            public static string GetStringDescription<T>(this T enumValue)
                where T : struct, IConvertible
            {
                if (!typeof(T).IsEnum)
                    return null;

                var description = enumValue.ToString();
                var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

                if (fieldInfo != null)
                {
                    var attrs = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (attrs != null && attrs.Length > 0)
                    {
                        description = ((DescriptionAttribute)attrs[0]).Description;
                    }
                }

                return description;
            }

        public class DescriptionAttributes<T>
        {
            protected List<DescriptionAttribute> Attributes = new List<DescriptionAttribute>();
            public List<string> Descriptions { get; set; }

            public DescriptionAttributes()
            {
                RetrieveAttributes();
                Descriptions = Attributes.Select(x => x.Description).ToList();
            }

            private void RetrieveAttributes()
            {
                foreach (var attribute in typeof(T).GetMembers().SelectMany(member => member.GetCustomAttributes(typeof(DescriptionAttribute), true).Cast<DescriptionAttribute>()))
                {
                    Attributes.Add(attribute);
                }
            }
        }
    }

    



}
