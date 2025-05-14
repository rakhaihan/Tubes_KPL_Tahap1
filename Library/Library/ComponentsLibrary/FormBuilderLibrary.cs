using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ComponentsLibrary
{
    public static class FormBuilder
    {
        public static string GenerateForm<T>(Dictionary<string, Func<T, string>> fieldGenerators, T data)
        {
            if (fieldGenerators == null)
                throw new ArgumentNullException(nameof(fieldGenerators));
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            var builder = new StringBuilder();
            foreach (var field in fieldGenerators)
            {
                string label = field.Key;
                string value = field.Value.Invoke(data);
                builder.AppendLine($"{label}: {value}");
            }
            return builder.ToString();
        }
    }
}

