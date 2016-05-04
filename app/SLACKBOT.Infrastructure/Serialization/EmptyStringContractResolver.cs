using System;
using System.Reflection;

using Newtonsoft.Json.Serialization;

namespace SLACKBOT.Infrastructure.Serialization
{
    /// <summary>
    /// Json.Net contract resolver than writes null string as "" instead of null.
    /// </summary>
    public class EmptyStringContractResolver : CamelCasePropertyNamesContractResolver
    {
        #region Methods

        protected override IValueProvider CreateMemberValueProvider(MemberInfo member)
        {
            IValueProvider valueProvider = null;

            switch (member.MemberType)
            {
                case MemberTypes.Property:
                    valueProvider = CreatePropertyProvider(member);
                    break;
                case MemberTypes.Field:
                    valueProvider = CreateFieldProvider(member);
                    break;
            }

            return valueProvider ?? base.CreateMemberValueProvider(member);
        }

        private static IValueProvider CreateFieldProvider(MemberInfo member)
        {
            var fieldInfo = member as FieldInfo;

            if (fieldInfo != null)
            {
                return CreateProvider(member, fieldInfo.FieldType);
            }

            return null;
        }

        private static IValueProvider CreatePropertyProvider(MemberInfo member)
        {
            var propertyInfo = member as PropertyInfo;

            if (propertyInfo != null)
            {
                return CreateProvider(member, propertyInfo.PropertyType);
            }

            return null;
        }

        private static IValueProvider CreateProvider(MemberInfo member, Type type)
        {
            return type == typeof(string) ? new StringValueProvider(member) : null;
        }

        #endregion
    }
}