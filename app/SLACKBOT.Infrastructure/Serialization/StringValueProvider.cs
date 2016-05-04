using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json.Serialization;

namespace SLACKBOT.Infrastructure.Serialization
{
    /// <summary>
    /// Json.Net custom string value provider to write null string as ""  instead of null.
    /// </summary>
    public class StringValueProvider : IValueProvider
    {
        #region Fields

        private readonly IValueProvider _dynamicValueProvider;

        #endregion

        #region Constructors

        public StringValueProvider(MemberInfo memberInfo)
        {
            this._dynamicValueProvider = new DynamicValueProvider(memberInfo);
        }

        #endregion

        #region Methods

        public object GetValue(object target)
        {
            return this._dynamicValueProvider.GetValue(target) ?? string.Empty;
        }

        public void SetValue(object target, object value)
        {
            var str = value as string;

            this._dynamicValueProvider.SetValue(target, string.IsNullOrEmpty(str) ? string.Empty : value);
        }

        #endregion
    }
}
