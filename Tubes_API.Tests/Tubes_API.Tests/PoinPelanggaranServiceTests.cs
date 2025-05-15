using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_API.Services;
using Tubes_API.Models;

namespace Tubes_API.Tests
{
    [TestClass]
    public class PoinPelanggaranServiceTests
    {
        private PoinPelanggaranService _service;

        [TestInitialize]
        public void Init() => _service = new PoinPelanggaranService();

        [TestMethod]
        public void Add_ShouldAssignId()
        {
            _service.Add(new PoinPelanggaran { SiswaId = 1, Deskripsi = "Terlambat", Poin = 5 });
            var all = _service.GetAll();

            Assert.AreEqual(1, all.Count);
            Assert.AreEqual(1, all[0].Id);
        }

        [TestMethod]
        public void UpdateStatus_ShouldUpdateCorrectly()
        {
            _service.Add(new PoinPelanggaran { SiswaId = 1, Deskripsi = "Seragam", Poin = 3 });
            _service.UpdateStatus(1, StatusPelanggaran.Disetujui);

            Assert.AreEqual(StatusPelanggaran.Disetujui, _service.GetById(1).Status);
        }

        [TestMethod]
        public void Delete_ShouldRemovePelanggaran()
        {
            _service.Add(new PoinPelanggaran { SiswaId = 1, Deskripsi = "Merokok", Poin = 10 });
            _service.Delete(1);

            Assert.AreEqual(0, _service.GetAll().Count);
        }

        [TestMethod]
        public void GetTotalPoinDisetujui_ShouldSumCorrectly()
        {
            _service.Add(new PoinPelanggaran { SiswaId = 1, Poin = 5, Status = StatusPelanggaran.Disetujui });
            _service.Add(new PoinPelanggaran { SiswaId = 1, Poin = 3, Status = StatusPelanggaran.Menunggu });

            Assert.AreEqual(5, _service.GetTotalPoinDisetujuiBySiswa(1));
        }
    }
}
