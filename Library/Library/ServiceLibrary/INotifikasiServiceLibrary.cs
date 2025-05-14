using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ModelLibrary;

namespace Library.ServiceLibrary
{
    public interface INotifikasiService
    {
    void KirimNotifikasi(string pesan, Pengguna penerima);
    }
}
