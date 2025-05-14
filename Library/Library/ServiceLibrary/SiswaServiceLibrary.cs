using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ModelLibrary;

namespace Library.ServiceLibrary
{
    public interface ISiswaService
    {
        void TambahSiswa(Siswa siswa);
        Siswa CariSiswa(int id);
        List<Siswa> GetSemua();
        void UpdateSiswa(int id, Siswa updatedSiswa);
        bool HapusSiswa(int id);
    }
    public class SiswaService : ISiswaService
    {
        private readonly List<Siswa> _daftarSiswa = new List<Siswa>();

        public void TambahSiswa(Siswa siswa)
        {
            if (siswa == null)
                throw new ArgumentNullException(nameof(siswa), "Objek siswa tidak boleh null.");
            if (string.IsNullOrWhiteSpace(siswa.Nama))
                throw new ArgumentException("Nama siswa tidak boleh kosong.", nameof(siswa.Nama));
            if (string.IsNullOrWhiteSpace(siswa.Kelas))
                throw new ArgumentException("Kelas tidak boleh kosong.", nameof(siswa.Kelas));

            _daftarSiswa.Add(siswa);
        }

        public Siswa CariSiswa(int id)
        {
            if (id <= 0)
                return null;
            return _daftarSiswa.FirstOrDefault(s => s.Id == id);
        }

        public List<Siswa> GetSemua()
        {
            return _daftarSiswa.ToList();
        }

        public void UpdateSiswa(int id, Siswa updatedSiswa)
        {
            if (updatedSiswa == null)
                throw new ArgumentNullException(nameof(updatedSiswa), "Objek siswa tidak boleh null.");
            if (string.IsNullOrWhiteSpace(updatedSiswa.Nama))
                throw new ArgumentException("Nama siswa tidak boleh kosong.", nameof(updatedSiswa.Nama));
            if (string.IsNullOrWhiteSpace(updatedSiswa.Kelas))
                throw new ArgumentException("Kelas tidak boleh kosong.", nameof(updatedSiswa.Kelas));

            var siswa = CariSiswa(id);
            if (siswa != null)
            {
                siswa.Nama = updatedSiswa.Nama;
                siswa.Kelas = updatedSiswa.Kelas;
                siswa.TotalPoin = updatedSiswa.TotalPoin;
                siswa.RiwayatPelanggaran = updatedSiswa.RiwayatPelanggaran ?? new List<Pelanggaran>();
            }
        }

        public bool HapusSiswa(int id)
        {
            var siswa = CariSiswa(id);
            if (siswa == null)
                return false;
            _daftarSiswa.Remove(siswa);
            return true;
        }
    }
}
