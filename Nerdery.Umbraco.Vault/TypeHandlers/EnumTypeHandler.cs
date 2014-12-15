﻿using System;
using Nerdery.Umbraco.Vault.Attributes;
using Nerdery.Umbraco.Vault.Extensions;

namespace Nerdery.Umbraco.Vault.TypeHandlers
{
    /// <summary>
    /// Used for binding WYSIWYG fields in Umbraco. Executes Macros within Rich Text Fields.
    /// </summary>
    [IgnoreAutoLoad]
    public class EnumTypeHandler : ITypeHandler
    {
        public object GetAsType<T>(object input)
        {
            // Due to the current constraint of "where T : class", this doesn't actually support enums
            // This should be revisited in a future version, but for now, the GetAsEnum is a workaround.
            throw new NotSupportedException("The EnumTypeHandler doesn't suppor the GetAsType method.");
        }

        public object GetAsEnum<T>(object input)
        {
            var stringValue = input.ToString();
            if (string.IsNullOrWhiteSpace(stringValue))
                return Enum.ToObject(typeof(T), 0);
            return stringValue.ConvertToEnum<T>();
        }
    	
        public Type TypeSupported
        {
            get { return typeof (Enum); }
        }

		

	}
}