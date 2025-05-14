using NUnit.Framework;
using Library.ConfigurationLibrary;

namespace Library.ConfigurationLibrary.Tests
{
    [TestFixture]
    public class AppConfigTests
    {
        [Test]
        public void AppConfig_DefaultConstructor_SetsDefaultValues()
        {
            // Arrange & Act
            var config = new AppConfig();

            // Assert
            Assert.That(config.BatasPoinPeringatan, Is.EqualTo(0));
            Assert.That(config.BatasPoinPanggilanOrangTua, Is.EqualTo(0));
            Assert.That(config.BatasPoinSkorsing, Is.EqualTo(0));
            Assert.That(config.NotifikasiEmailAktif, Is.False);
            Assert.That(config.NotifikasiWhatsappAktif, Is.False);
            Assert.That(config.DefaultRoleUserBaru, Is.EqualTo(string.Empty));
        }

        [Test]
        public void AppConfig_ParameterizedConstructor_SetsValuesCorrectly()
        {
            // Arrange
            int batasPoinPeringatan = 10;
            int batasPoinPanggilanOrangTua = 20;
            int batasPoinSkorsing = 30;
            bool notifEmail = true;
            bool notifWa = false;
            string defaultRole = "Student";

            // Act
            var config = new AppConfig(batasPoinPeringatan, batasPoinPanggilanOrangTua, batasPoinSkorsing, notifEmail, notifWa, defaultRole);

            // Assert
            Assert.That(config.BatasPoinPeringatan, Is.EqualTo(batasPoinPeringatan));
            Assert.That(config.BatasPoinPanggilanOrangTua, Is.EqualTo(batasPoinPanggilanOrangTua));
            Assert.That(config.BatasPoinSkorsing, Is.EqualTo(batasPoinSkorsing));
            Assert.That(config.NotifikasiEmailAktif, Is.EqualTo(notifEmail));
            Assert.That(config.NotifikasiWhatsappAktif, Is.EqualTo(notifWa));
            Assert.That(config.DefaultRoleUserBaru, Is.EqualTo(defaultRole));
        }

        [Test]
        public void AppConfig_ParameterizedConstructor_NullDefaultRole_SetsEmptyString()
        {
            // Arrange
            string defaultRole = null;

            // Act
            var config = new AppConfig(10, 20, 30, true, false, defaultRole);

            // Assert
            Assert.That(config.DefaultRoleUserBaru, Is.EqualTo(string.Empty));
        }
    }
}