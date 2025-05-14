using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ModelLibrary;

namespace Library.ServiceLibrary
{
    public class NotifikasiService : INotifikasiService
    {
        public event Action<string, Pengguna> OnNotifikasi;
        public void KirimNotifikasi(string pesan, Pengguna penerima)
        {
            if (string.IsNullOrWhiteSpace(pesan))
                throw new ArgumentNullException(nameof(pesan), "Pesan tidak boleh kosong.");
            if (penerima == null)
                throw new ArgumentNullException(nameof(penerima), "Penerima tidak boleh null.");

            string notifikasi = $"[NOTIFIKASI] Kepada {penerima.Username}: {pesan}";
            OnNotifikasi?.Invoke(notifikasi, penerima);
        }
    }

}
