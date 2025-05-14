using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using Tubes_Console.Components;

namespace Tubes_Console.Tests.ComponentsTest
{
    [TestClass]
    public class ComponentsTest
    {
        private class DummyData
        {
            public string NIM { get; set; }
            public string Nama { get; set; }
            public string Pelanggaran { get; set; }
            public int Poin { get; set; }
            public DateTime Tanggal { get; set; }
        }

        [TestMethod]
        public void TampilkanForm_ShouldPrintCorrectOutput()
        {
            var data = new DummyData
            {
                NIM = "123456",
                Nama = "Azki",
                Pelanggaran = "Merokok",
                Poin = 20,
                Tanggal = new DateTime(2025, 5, 1)
            };

            var fields = new Dictionary<string, Func<DummyData, string>>
            {
                { "NIM", d => d.NIM },
                { "Nama", d => d.Nama },
                { "Pelanggaran", d => d.Pelanggaran },
                { "Poin", d => d.Poin.ToString() },
                { "Tanggal", d => d.Tanggal.ToString("yyyy-MM-dd") }
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            FormBuilder.TampilkanForm(fields, data);

            var output = sw.ToString().Trim().Split(Environment.NewLine);

            CollectionAssert.Contains(output, "NIM: 123456");
            CollectionAssert.Contains(output, "Nama: Azki");
            CollectionAssert.Contains(output, "Pelanggaran: Merokok");
            CollectionAssert.Contains(output, "Poin: 20");
            CollectionAssert.Contains(output, "Tanggal: 2025-05-01");
        }

        [TestMethod]
        public void RenderTable_ShouldPrintCorrectTable()
        {
            var dataList = new List<DummyData>
            {
                new DummyData { NIM = "111", Nama = "Abdul", Pelanggaran = "Bolos", Poin = 10, Tanggal = DateTime.Today },
                new DummyData { NIM = "222", Nama = "Malik", Pelanggaran = "Merokok", Poin = 20, Tanggal = DateTime.Today }
            };

            var columns = new Dictionary<string, Func<DummyData, string>>
            {
                { "NIM", d => d.NIM },
                { "Nama", d => d.Nama },
                { "Pelanggaran", d => d.Pelanggaran },
                { "Poin", d => d.Poin.ToString() },
                { "Tanggal", d => d.Tanggal.ToString("yyyy-MM-dd") }
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            TableRenderer.Render(dataList, columns);

            var output = sw.ToString().Trim().Split(Environment.NewLine);

            Assert.AreEqual("NIM | Nama | Pelanggaran | Poin | Tanggal", output[0]);
            CollectionAssert.Contains(output, $"111 | Abdul | Bolos | 10 | {DateTime.Today:yyyy-MM-dd}");
            CollectionAssert.Contains(output, $"222 | Malik | Merokok | 20 | {DateTime.Today:yyyy-MM-dd}");
        }
    }
}
