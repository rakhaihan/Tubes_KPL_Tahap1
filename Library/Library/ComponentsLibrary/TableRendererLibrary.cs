using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ComponentsLibrary
{
    public static class TableRenderer
    {
        public static string Render<T>(List<T> data, Dictionary<string, Func<T, string>> columns)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (columns == null)
                throw new ArgumentNullException(nameof(columns));

            var builder = new StringBuilder();
            builder.AppendLine(string.Join(" | ", columns.Keys));

            foreach (var item in data)
            {
                var row = columns.Values.Select(selector => selector(item));
                builder.AppendLine(string.Join(" | ", row));
            }

            return builder.ToString();
        }
    }
}

