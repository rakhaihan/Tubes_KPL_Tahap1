using System;
using System.Collections.Generic;
using Library.AutomataLibrary;
using Library.ModelLibrary;
using Library.TableDrivenLibrary;
using Library.ConfigurationLibrary;
using Library.ServiceLibrary;
using Tubes_Console.Library.ServiceLibrary;

namespace Library.ServiceLibrary
{
    public class PelanggaranService : IPelanggaranService
    {
        private readonly AppConfig _config;
        public PelanggaranService(AppConfig config)
        {
            _config = config ?? throw new ArgumentNullException(nameof(config));
        }
        public string TambahPelanggaran(Siswa siswa, Pelanggaran pelanggaran)
        {
            if (siswa == null)
                throw new ArgumentNullException(nameof(siswa), "Objek siswa tidak boleh null.");
            if (pelanggaran == null)
                throw new ArgumentNullException(nameof(pelanggaran), "Objek pelanggaran tidak boleh null.");
            if (string.IsNullOrWhiteSpace(pelanggaran.Jenis))
                throw new ArgumentException("Jenis pelanggaran tidak boleh kosong.", nameof(pelanggaran.Jenis));

            siswa.RiwayatPelanggaran.Add(pelanggaran);
            siswa.TotalPoin += pelanggaran.Poin;

            if (siswa.TotalPoin >= _config.BatasPoinSkorsing)
                return "Skorsing";
            else if (siswa.TotalPoin >= _config.BatasPoinPanggilanOrangTua)
                return "Panggilan Orang Tua";
            else if (siswa.TotalPoin >= _config.BatasPoinPeringatan)
                return "Peringatan Lisan";
            return null;
        }
        public bool UbahStatusPelanggaran(Pelanggaran pelanggaran, Trigger trigger)
        {
            if (pelanggaran == null)
                throw new ArgumentNullException(nameof(pelanggaran), "Objek pelanggaran tidak boleh null.");

            var sm = new PelanggaranStateMachine(pelanggaran.Status);
            try
            {
                sm.Activate(trigger);
            }
            catch (InvalidOperationException)
            {
                return false; 
            }

            if (sm.CurrentState != pelanggaran.Status)
            {
                pelanggaran.Status = sm.CurrentState;
                return true;
            }
            return false;
        }
    }
}
