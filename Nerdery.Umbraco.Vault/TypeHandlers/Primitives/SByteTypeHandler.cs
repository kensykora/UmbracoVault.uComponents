﻿using System;

namespace Nerdery.Umbraco.Vault.TypeHandlers.Primitives
{
    public class SByteTypeHandler : ITypeHandler
    {
        private object Get(string stringValue)
        {
            sbyte result;

            sbyte.TryParse(stringValue, out result);

            return result;
        }

        public object GetAsType<T>(object input)
    	{
			return Get(input.ToString());
    	}

        public Type TypeSupported
        {
            get { return typeof(sbyte); }
        }
    }
}