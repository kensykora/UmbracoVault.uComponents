﻿using System;

namespace Nerdery.Umbraco.Vault.TypeHandlers.Primitives
{
    public class LongTypeHandler : ITypeHandler
    {
        private object Get(string stringValue)
        {
            long result;

            long.TryParse(stringValue, out result);

            return result;
        }

        public object GetAsType<T>(object input)
    	{
			return Get(input.ToString());
    	}

        public Type TypeSupported
        {
            get { return typeof (long); }
        }
    }
}
