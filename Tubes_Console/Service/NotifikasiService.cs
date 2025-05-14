using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes_Console.Model;

namespace Tubes_Console.Service
{
    public class NotifikasiService
    {
        public void KirimNotifikasi(string pesan, Pengguna penerima)
        {
            Console.WriteLine($"[NOTIFIKASI] Kepada {penerima.Username}: {pesan}");
            
        }
    }
}
