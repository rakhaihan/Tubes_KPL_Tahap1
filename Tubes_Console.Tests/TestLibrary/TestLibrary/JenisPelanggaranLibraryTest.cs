using NUnit.Framework;
using Library.TableDrivenLibrary;

namespace Library.TableDrivenLibrary.Tests
{
    [TestFixture]
    public class JenisPelanggaranTests
    {
        [Test]
        public void JenisPelanggaran_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange
            string nama = "Terlambat";
            LevelPelanggaran level = LevelPelanggaran.RINGAN;
            int poin = 5;

            // Act
            var jenisPelanggaran = new JenisPelanggaran(nama, level, poin);

            // Assert
            Assert.That(jenisPelanggaran.Nama, Is.EqualTo(nama));
            Assert.That(jenisPelanggaran.Level, Is.EqualTo(level));
            Assert.That(jenisPelanggaran.Poin, Is.EqualTo(poin));
        }

        [Test]
        public void JenisPelanggaran_Constructor_NullNama_SetsEmptyString()
        {
            // Arrange
            string nama = null;
            LevelPelanggaran level = LevelPelanggaran.SEDANG;
            int poin = 10;

            // Act
            var jenisPelanggaran = new JenisPelanggaran(nama, level, poin);

            // Assert
            Assert.That(jenisPelanggaran.Nama, Is.EqualTo(string.Empty));
            Assert.That(jenisPelanggaran.Level, Is.EqualTo(level));
            Assert.That(jenisPelanggaran.Poin, Is.EqualTo(poin));
        }

        [Test]
        public void JenisPelanggaran_SetProperties_UpdatesValues()
        {
            // Arrange
            var jenisPelanggaran = new JenisPelanggaran("Bolos", LevelPelanggaran.BERAT, 20);

            // Act
            jenisPelanggaran.Nama = "Merokok";
            jenisPelanggaran.Level = LevelPelanggaran.BERAT;
            jenisPelanggaran.Poin = 50;

            // Assert
            Assert.That(jenisPelanggaran.Nama, Is.EqualTo("Merokok"));
            Assert.That(jenisPelanggaran.Level, Is.EqualTo(LevelPelanggaran.BERAT));
            Assert.That(jenisPelanggaran.Poin, Is.EqualTo(50));
        }
    }
}