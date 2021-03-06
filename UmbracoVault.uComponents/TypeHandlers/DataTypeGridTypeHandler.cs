﻿using System;
using System.Collections.Generic;
using System.Linq;

using uComponents.DataTypes.DataTypeGrid.Model;

using UmbracoVault.Attributes;
using UmbracoVault.Exceptions;
using UmbracoVault.Extensions;
using UmbracoVault.TypeHandlers;

namespace UmbracoVault.uComponents.TypeHandlers
{
    [IgnoreTypeHandlerAutoRegistration]
    public class DataTypeGridTypeHandler : ITypeHandler
    {
        public object GetAsType<T>(object input)
        {
            var result = new List<T>();
            var rows = input as GridRowCollection;
            if (rows == null)
            {
                return result;
            }
            foreach (var row in rows)
            {
                var item = typeof(T).CreateWithNoParams<T>();

                // ReSharper disable once CompareNonConstrainedGenericWithNull
                if (item == null)
                {
                    throw new ConstructorUnavailableException(typeof(T));
                }

                var currentRow = row;
                Vault.Context.FillClassProperties(item, (alias, recursive) =>
                {
                    // recursive is currently ignored in this case

                    string value = null;
                    if (!string.IsNullOrWhiteSpace(alias) && currentRow != null)
                    {
                        var cell = currentRow.FirstOrDefault(c => c.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase));
                        if (cell != null)
                        {
                            value = string.IsNullOrWhiteSpace(cell.Value) ? null : cell.Value;
                        }
                    }

                    return value;
                });

                result.Add(item);
            }
            return result;
        }

        public Type TypeSupported => typeof(string);
    }
}