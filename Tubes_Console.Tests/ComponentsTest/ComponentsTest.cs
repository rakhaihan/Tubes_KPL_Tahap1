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
            public string Name { get; set; }
            public int Age { get; set; }
        }

        [TestMethod]
        public void TampilkanForm_ShouldPrintCorrectOutput()
        {
            var data = new DummyData { Name = "Alice", Age = 25 };

            var fields = new Dictionary<string, Func<DummyData, string>>
            {
                { "Nama", d => d.Name },
                { "Umur", d => d.Age.ToString() }
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            FormBuilder.TampilkanForm(fields, data);

            var output = sw.ToString().Trim().Split(Environment.NewLine);

            CollectionAssert.Contains(output, "Nama: Alice");
            CollectionAssert.Contains(output, "Umur: 25");
        }

        [TestMethod]
        public void RenderTable_ShouldPrintCorrectTable()
        {
            var dataList = new List<DummyData>
            {
                new DummyData { Name = "Bob", Age = 30 },
                new DummyData { Name = "Charlie", Age = 40 }
            };

            var columns = new Dictionary<string, Func<DummyData, string>>
            {
                { "Nama", d => d.Name },
                { "Umur", d => d.Age.ToString() }
            };

            using var sw = new StringWriter();
            Console.SetOut(sw);

            TableRenderer.Render(dataList, columns);

            var output = sw.ToString().Trim().Split(Environment.NewLine);

            Assert.AreEqual("Nama | Umur", output[0]);
            CollectionAssert.Contains(output, "Bob | 30");
            CollectionAssert.Contains(output, "Charlie | 40");
        }
    }
}
