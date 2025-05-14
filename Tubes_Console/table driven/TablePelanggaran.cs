using System;
using System.Collections.Generic;
using System.Diagnostics; // Untuk Debug.Assert
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes_Console.table_driven
{
    public static class TabelPelanggaran
    {
        public static readonly Dictionary<string, JenisPelanggaran> Daftar = new Dictionary<string, JenisPelanggaran>
        {
            { "Tidak Membawa Buku", new JenisPelanggaran("Tidak Membawa Buku", LevelPelanggaran.RINGAN, 5) },
            { "Terlambat Masuk", new JenisPelanggaran("Terlambat Masuk", LevelPelanggaran.SEDANG, 10) },
            { "Merokok", new JenisPelanggaran("Merokok", LevelPelanggaran.BERAT, 20) }
        };

        // Konstruktor statis untuk memastikan dictionary tidak kosong (Invariant)
        static TabelPelanggaran()
        {
            if (Daftar == null || Daftar.Count == 0)
            {
                throw new InvalidOperationException("Daftar pelanggaran tidak boleh kosong.");
            }
        }

        // Metode validasi untuk preconditions
        private static void ValidateNamaPelanggaran(string nama)
        {
            if (string.IsNullOrWhiteSpace(nama))
            {
                throw new ArgumentException("Nama pelanggaran tidak boleh kosong atau null.");
            }

            if (!Daftar.ContainsKey(nama))
            {
                throw new KeyNotFoundException($"Pelanggaran '{nama}' tidak ditemukan.");
            }
        }

        // Pencarian lebih cepat dengan Dictionary
        public static int GetPoin(string nama)
        {
            // Memastikan preconditions
            ValidateNamaPelanggaran(nama);

            int poin = Daftar[nama].Poin;

            // Memastikan postconditions
            Debug.Assert(poin >= 0, "Poin pelanggaran harus bernilai positif.");

            return poin;
        }
    }
}
