using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using Tubes_Console.Configuration;
using System.Text.Json;
using global::Tubes_Console.Configuration;

namespace Tubes_Console.Tests.ConfigurationTest
{
   
    
        [TestClass]
        public class configtest
        {
            private const string TestConfigFilePath = "AppConfig.json";

            [TestInitialize]
            public void Setup()
            {
                if (File.Exists(TestConfigFilePath))
                {
                    File.Delete(TestConfigFilePath);
                }
            }

            [TestMethod]
            public void ConfigManager_ShouldCreateDefaultConfig_WhenFileNotExist()
            {
                // Arrange
                Assert.IsFalse(File.Exists(TestConfigFilePath));

                // Act
                var configManager = new ConfigManager();

                // Assert
                Assert.IsNotNull(configManager.Config);
                Assert.AreEqual(10, configManager.Config.BatasPoinPeringatan);
                Assert.AreEqual(20, configManager.Config.BatasPoinPanggilanOrangTua);
                Assert.AreEqual(30, configManager.Config.BatasPoinSkorsing);
                Assert.IsTrue(configManager.Config.NotifikasiEmailAktif);
                Assert.IsFalse(configManager.Config.NotifikasiWhatsappAktif);
                Assert.AreEqual("Siswa", configManager.Config.DefaultRoleUserBaru);
                Assert.IsTrue(File.Exists(TestConfigFilePath));
            }

            [TestMethod]
            public void ConfigManager_ShouldLoadFromExistingConfigFile()
            {
                // Arrange
                var testConfig = new AppConfig(5, 15, 25, false, true, "Guru");
                var options = new JsonSerializerOptions { WriteIndented = true };
                var json = JsonSerializer.Serialize(testConfig, options);
                File.WriteAllText(TestConfigFilePath, json);

                // Act
                var configManager = new ConfigManager();

                // Assert
                Assert.AreEqual(5, configManager.Config.BatasPoinPeringatan);
                Assert.AreEqual(15, configManager.Config.BatasPoinPanggilanOrangTua);
                Assert.AreEqual(25, configManager.Config.BatasPoinSkorsing);
                Assert.IsFalse(configManager.Config.NotifikasiEmailAktif);
                Assert.IsTrue(configManager.Config.NotifikasiWhatsappAktif);
                Assert.AreEqual("Guru", configManager.Config.DefaultRoleUserBaru);
            }
        }
}


