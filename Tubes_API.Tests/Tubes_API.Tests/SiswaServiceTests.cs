using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_API.Services;
using Tubes_API.Models;
using System.Collections.Generic;

namespace Tubes_API.Tests
{
    [TestClass]
    public class SiswaServiceTests
    {
        private SiswaService _service;

        [TestInitialize]
        public void Init() => _service = new SiswaService();

        [TestMethod]
        public void Add_ShouldAddSiswa()
        {
            _service.Add(new Siswa { Id = 1, Nama = "Raihan", Kelas = "XII IPA 1" });

            Assert.AreEqual(1, _service.GetAll().Count);
        }

        [TestMethod]
        public void Update_ShouldModifyData()
        {
            _service.Add(new Siswa { Id = 1, Nama = "Raihan", Kelas = "XII IPA 1" });
            _service.Update(1, new Siswa { Id = 1, Nama = "Updated", Kelas = "XII IPS", TotalPoin = 15 });

            var updated = _service.GetById(1);
            Assert.AreEqual("Updated", updated.Nama);
            Assert.AreEqual("XII IPS", updated.Kelas);
        }

        [TestMethod]
        public void TambahPelanggaran_ShouldUpdateTotalAndRiwayat()
        {
            _service.Add(new Siswa { Id = 1, Nama = "A", Kelas = "XII" });
            _service.TambahPelanggaran(1, new PoinPelanggaran { Deskripsi = "Membolos", Poin = 10 });

            var siswa = _service.GetById(1);
            Assert.AreEqual(1, siswa.RiwayatPelanggaran.Count);
            Assert.AreEqual(10, siswa.TotalPoin);
        }
    }
}
