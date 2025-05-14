using NUnit.Framework;
using Library.ComponentsLibrary;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLibrary.Tests
{
    [TestFixture]
    public class FormBuilderTests
    {
        private class TestData
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        private Dictionary<string, Func<TestData, string>> _fieldGenerators;
        private TestData _data;

        [SetUp]
        public void Setup()
        {
            // Inisialisasi data dan field generators untuk setiap tes
            _fieldGenerators = new Dictionary<string, Func<TestData, string>>
            {
                { "Nama", data => data.Name },
                { "Umur", data => data.Age.ToString() }
            };
            _data = new TestData { Name = "John Doe", Age = 25 };
        }

        [Test]
        public void GenerateForm_ValidData_ReturnsCorrectForm()
        {
            // Arrange
            var expected = "Nama: John Doe\nUmur: 25\n";

            // Act
            var result = FormBuilder.GenerateForm(_fieldGenerators, _data);

            // Assert
            // Normalisasi newline untuk mendukung perbedaan platform (Windows: \r\n, Unix: \n)
            Assert.That(result.Replace("\r\n", "\n"), Is.EqualTo(expected), "Formulir harus sesuai dengan format yang diharapkan.");
        }

        [Test]
        public void GenerateForm_EmptyFieldGenerators_ReturnsEmptyForm()
        {
            // Arrange
            var emptyGenerators = new Dictionary<string, Func<TestData, string>>();
            var expected = "";

            // Act
            var result = FormBuilder.GenerateForm(emptyGenerators, _data);

            // Assert
            Assert.That(result, Is.EqualTo(expected), "Formulir kosong harus mengembalikan string kosong.");
        }

        [Test]
        public void GenerateForm_NullFieldGenerators_ThrowsArgumentNullException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
                FormBuilder.GenerateForm(null, _data));
            Assert.That(ex.ParamName, Is.EqualTo("fieldGenerators"), "Parameter yang salah harus fieldGenerators.");
        }

        [Test]
        public void GenerateForm_NullData_ThrowsArgumentNullException()
        {
            // Act & Assert
            var ex = Assert.Throws<ArgumentNullException>(() =>
                FormBuilder.GenerateForm(_fieldGenerators, null));
            Assert.That(ex.ParamName, Is.EqualTo("data"), "Parameter yang salah harus data.");
        }
    }
}