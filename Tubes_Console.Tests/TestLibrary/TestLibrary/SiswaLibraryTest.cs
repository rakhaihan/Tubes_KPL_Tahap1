using NUnit.Framework;
using Library.ModelLibrary;
using System.Collections.Generic;

namespace Library.ModelLibrary.Tests
{
    [TestFixture]
    public class SiswaTests
    {
        [Test]
        public void Siswa_DefaultConstructor_SetsDefaultValues()
        {
            // Arrange & Act
            var siswa = new Siswa();

            // Assert
            Assert.That(siswa.Id, Is.EqualTo(0));
            Assert.That(siswa.Nama, Is.EqualTo(string.Empty));
            Assert.That(siswa.Kelas, Is.EqualTo(string.Empty));
            Assert.That(siswa.TotalPoin, Is.EqualTo(0));
            Assert.That(siswa.RiwayatPelanggaran, Is.Not.Null);
            Assert.That(siswa.RiwayatPelanggaran.Count, Is.EqualTo(0));
        }

        [Test]
        public void Siswa_SetProperties_ValuesAreSetCorrectly()
        {
            // Arrange
            var siswa = new Siswa
            {
                Id = 1,
                Nama = "John Doe",
                Kelas = "XII IPA 1",
                TotalPoin = 50
            };

            // Act (properties are already set)

            // Assert
            Assert.That(siswa.Id, Is.EqualTo(1));
            Assert.That(siswa.Nama, Is.EqualTo("John Doe"));
            Assert.That(siswa.Kelas, Is.EqualTo("XII IPA 1"));
            Assert.That(siswa.TotalPoin, Is.EqualTo(50));
        }

        [Test]
        public void Siswa_RiwayatPelanggaran_AddPelanggaran_UpdatesList()
        {
            // Arrange
            var siswa = new Siswa();
            var pelanggaran = new Pelanggaran(); // Assuming Pelanggaran class exists

            // Act
            siswa.RiwayatPelanggaran.Add(pelanggaran);

            // Assert
            Assert.That(siswa.RiwayatPelanggaran.Count, Is.EqualTo(1));
            Assert.That(siswa.RiwayatPelanggaran[0], Is.EqualTo(pelanggaran));
        }
    }
}