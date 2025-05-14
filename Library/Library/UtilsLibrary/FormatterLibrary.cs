using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.UtilsLibrary
{
    public static class Formatter
    {
        public static string FormatTanggal(DateTime tanggal) => tanggal.ToString("dd MMM yyyy");
    }
}
