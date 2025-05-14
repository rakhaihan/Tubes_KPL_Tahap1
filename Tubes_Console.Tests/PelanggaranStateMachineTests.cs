using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tubes_Console.Automata;
using Tubes_Console.Model;
using System;

namespace Tubes_Console.Tests
{
    [TestClass]
    public class PelanggaranStateMachineTests
    {
        [TestMethod]
        public void Activate_ValidTransition_ChangesState()
        {
            var machine = new PelanggaranStateMachine();
            Assert.AreEqual(StatusPelanggaran.DILAPORKAN, machine.CurrentState);

            machine.Activate(Trigger.SETUJUI);
            Assert.AreEqual(StatusPelanggaran.DISETUJUI, machine.CurrentState);

            machine.Activate(Trigger.BERI_SANKSI);
            Assert.AreEqual(StatusPelanggaran.DIBERI_SANKSI, machine.CurrentState);

            machine.Activate(Trigger.SELESAIKAN);
            Assert.AreEqual(StatusPelanggaran.SELESAI, machine.CurrentState);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Activate_InvalidTrigger_ThrowsException()
        {
            var machine = new PelanggaranStateMachine();
            machine.Activate(Trigger.BERI_SANKSI); // Salah urutan
        }
    }
}
