using NUnit.Framework;
using Library.UtilsLibrary;
using System;

namespace Library.UtilsLibrary.Tests
{
    [TestFixture]
    public class FormatterTests
    {
        [Test]
        public void FormatTanggal_ValidDateTime_ReturnsCorrectFormat()
        {
            // Arrange
            DateTime tanggal = new DateTime(2025, 5, 14);
            string expected = "14 May 2025";

            // Act
            string result = Formatter.FormatTanggal(tanggal);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FormatTanggal_DifferentDate_ReturnsCorrectFormat()
        {
            // Arrange
            DateTime tanggal = new DateTime(2023, 12, 25);
            string expected = "25 Dec 2023";

            // Act
            string result = Formatter.FormatTanggal(tanggal);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void FormatTanggal_EdgeCaseDate_ReturnsCorrectFormat()
        {
            // Arrange
            DateTime tanggal = new DateTime(2025, 1, 1);
            string expected = "01 Jan 2025";

            // Act
            string result = Formatter.FormatTanggal(tanggal);

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}