using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tubes_Console.Automata;
using Tubes_Console.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tubes_Console.Tests.AutomataTest
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
