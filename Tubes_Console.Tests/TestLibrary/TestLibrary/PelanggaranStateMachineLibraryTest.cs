using NUnit.Framework;
using Library.AutomataLibrary;
using Library.ModelLibrary;

namespace TestLibrary.Tests
{
    [TestFixture]
    public class PelanggaranStateMachineTests
    {
        private PelanggaranStateMachine _stateMachine;

        [SetUp]
        public void Setup()
        {
            // Inisialisasi dengan status awal MENUNGGU untuk setiap tes
            _stateMachine = new PelanggaranStateMachine(StatusPelanggaran.MENUNGGU);
        }

        [Test]
        public void GetNextState_Menunggu_Setujui_ReturnsDilaporkan()
        {
            // Arrange: Sudah diatur di Setup

            // Act
            var nextState = _stateMachine.GetNextState(StatusPelanggaran.MENUNGGU, Trigger.SETUJUI);

            // Assert
            Assert.That(nextState, Is.EqualTo(StatusPelanggaran.DILAPORKAN), "Status harus berubah ke DILAPORKAN.");
        }

        [Test]
        public void GetNextState_Dilaporkan_Setujui_ReturnsDisetujui()
        {
            // Arrange
            _stateMachine = new PelanggaranStateMachine(StatusPelanggaran.DILAPORKAN);

            // Act
            var nextState = _stateMachine.GetNextState(StatusPelanggaran.DILAPORKAN, Trigger.SETUJUI);

            // Assert
            Assert.That(nextState, Is.EqualTo(StatusPelanggaran.DISETUJUI), "Status harus berubah ke DISETUJUI.");
        }
    }
}