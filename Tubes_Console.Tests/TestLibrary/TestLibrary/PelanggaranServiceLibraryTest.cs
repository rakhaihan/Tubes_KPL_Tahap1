using NUnit.Framework;
using Library.ConfigurationLibrary;
using Library.ModelLibrary;
using Library.ServiceLibrary;
using Library.AutomataLibrary;
using System;

namespace TestLibrary.Tests
{
    [TestFixture]
    public class PelanggaranServiceTests
    {
        private AppConfig _config;

        [SetUp]
        public void Setup()
        {
            _config = new AppConfig(10, 20, 30, true, false, "Siswa");
        }

        [Test]
        public void TambahPelanggaran_ValidData_AddsPelanggaranAndReturnsPeringatan()
        {
            // Arrange  
            var service = new PelanggaranService(_config);
            var siswa = new Siswa { Id = 1, Nama = "John", Kelas = "10A", TotalPoin = 5 };
            var pelanggaran = new Pelanggaran
            {
                Id = 1,
                SiswaId = 1,
                Jenis = "Terlambat Masuk",
                Poin = 5,
                Tanggal = DateTime.Now,
                Status = StatusPelanggaran.MENUNGGU
            };

            // Act  
            var result = service.TambahPelanggaran(siswa, pelanggaran);

            // Assert  
            Assert.That(result, Is.EqualTo("Peringatan Lisan"));
            Assert.That(siswa.TotalPoin, Is.EqualTo(10));
            Assert.That(siswa.RiwayatPelanggaran, Contains.Item(pelanggaran));
        }

        [Test]
        public void UbahStatusPelanggaran_ValidTrigger_ChangesStatus()
        {
            // Arrange  
            var service = new PelanggaranService(_config);
            var pelanggaran = new Pelanggaran { Status = StatusPelanggaran.DILAPORKAN };

            // Act  
            var result = service.UbahStatusPelanggaran(pelanggaran, Trigger.SETUJUI);

            // Assert  
            Assert.That(result, Is.True);
            Assert.That(pelanggaran.Status, Is.EqualTo(StatusPelanggaran.DISETUJUI));
        }

        [Test]
        public void TambahPelanggaran_NullSiswa_ThrowsArgumentNullException()
        {
            // Arrange  
            var service = new PelanggaranService(_config);
            var pelanggaran = new Pelanggaran { Jenis = "Terlambat Masuk", Poin = 5 };

            // Act & Assert  
            Assert.Throws<ArgumentNullException>(() =>
                service.TambahPelanggaran(null, pelanggaran));
        }
    }
}
