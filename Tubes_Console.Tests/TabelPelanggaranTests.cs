
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Diagnostics;
using Tubes_Console.table_driven;

namespace Tubes_Console.Tests
{
    [TestClass]
    public class TabelPelanggaranTests
    {
        [TestMethod]
        public void GetPoin_ValidNama_ReturnsCorrectPoin()
        {
            // Arrange
            string nama = "Terlambat Masuk";

            // Act
            int poin = TabelPelanggaran.GetPoin(nama);

            // Assert
            Assert.AreEqual(10, poin);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPoin_EmptyNama_ThrowsArgumentException()
        {
            // Act
            TabelPelanggaran.GetPoin("");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetPoin_NamaTidakDitemukan_ThrowsKeyNotFoundException()
        {
            // Act
            TabelPelanggaran.GetPoin("Melanggar Jam Malam");
        }

        [TestMethod]
        public void KonstruktorStatic_DaftarHarusBerisiData()
        {
            // Assert
            Assert.IsNotNull(TabelPelanggaran.Daftar);
            Assert.IsTrue(TabelPelanggaran.Daftar.Count > 0);
        }

        [TestMethod]
        public void GetPoin_PoinSelaluNonNegatif()
        {
            // Arrange
            string nama = "Merokok";

            // Act
            int poin = TabelPelanggaran.GetPoin(nama);

            // Assert (gandakan seperti Debug.Assert)
            Assert.IsTrue(poin >= 0, "Poin pelanggaran harus bernilai positif.");
        }
    }
}
