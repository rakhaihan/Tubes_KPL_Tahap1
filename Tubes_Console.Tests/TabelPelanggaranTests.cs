using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_Console.table_driven;
using System;

namespace Tubes_Console.Tests
{
    [TestClass]
    public class TabelPelanggaranTests
    {
        [TestMethod]
        public void GetPoin_ValidNama_ReturnsCorrectPoin()
        {
            int poin = TabelPelanggaran.GetPoin("Merokok");
            Assert.AreEqual(20, poin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPoin_EmptyNama_ThrowsArgumentException()
        {
            TabelPelanggaran.GetPoin("");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetPoin_InvalidNama_ThrowsKeyNotFoundException()
        {
            TabelPelanggaran.GetPoin("Pelanggaran Tidak Ada");
        }
    }
}
