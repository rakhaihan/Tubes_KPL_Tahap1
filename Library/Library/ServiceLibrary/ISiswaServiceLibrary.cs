using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Library.ModelLibrary;

namespace Tubes_Console.Library.ServiceLibrary
{

    public interface ISiswaService
    {
        void TambahSiswa(Siswa siswa);
        Siswa CariSiswa(int id);
        List<Siswa> GetSemua();
        void UpdateSiswa(int id, Siswa updatedSiswa);
        bool HapusSiswa(int id);
    }
}
