 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes_Console.table_driven;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace Tubes_Console.Tests.Table_drivenTest
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
