using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Library.ModelLibrary
{
    public class Siswa
    {
        public int Id { get; set; }
        public string Nama { get; set; } = string.Empty;
        public string Kelas { get; set; } = string.Empty;
        public int TotalPoin { get; set; }
        public List<Pelanggaran> RiwayatPelanggaran { get; set; } = new List<Pelanggaran>();
    }
}
