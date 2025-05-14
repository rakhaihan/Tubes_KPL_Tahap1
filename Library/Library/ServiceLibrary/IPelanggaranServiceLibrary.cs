using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ModelLibrary;
using Library.AutomataLibrary;

namespace Tubes_Console.Library.ServiceLibrary
{
    public interface IPelanggaranService
    {
        string TambahPelanggaran(Siswa siswa, Pelanggaran pelanggaran);
        bool UbahStatusPelanggaran(Pelanggaran pelanggaran, Trigger trigger);
    }
}
