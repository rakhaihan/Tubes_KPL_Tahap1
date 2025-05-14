using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.ModelLibrary;

namespace Library.AutomataLibrary
{
    public class PelanggaranStateMachine
    {
        private readonly struct Transisi
        {
            public StatusPelanggaran PrevState { get; }
            public StatusPelanggaran NextState { get; }
            public Trigger Trigger { get; }

            public Transisi(StatusPelanggaran prevState, StatusPelanggaran nextState, Trigger trigger)
            {
                if (!Enum.IsDefined(typeof(StatusPelanggaran), prevState) ||
                    !Enum.IsDefined(typeof(StatusPelanggaran), nextState) ||
                    !Enum.IsDefined(typeof(Trigger), trigger))
                {
                    throw new ArgumentException("Nilai status atau trigger tidak valid.");
                }
                PrevState = prevState;
                NextState = nextState;
                Trigger = trigger;
            }
        }

        private readonly Transisi[] transitions =
        {
            new Transisi(StatusPelanggaran.MENUNGGU, StatusPelanggaran.DILAPORKAN, Trigger.SETUJUI),
            new Transisi(StatusPelanggaran.DILAPORKAN, StatusPelanggaran.DISETUJUI, Trigger.SETUJUI),
            new Transisi(StatusPelanggaran.DISETUJUI, StatusPelanggaran.DIBERI_SANKSI, Trigger.BERI_SANKSI),
            new Transisi(StatusPelanggaran.DIBERI_SANKSI, StatusPelanggaran.SELESAI, Trigger.SELESAIKAN)
        };

        private StatusPelanggaran _currentState;
        public PelanggaranStateMachine(StatusPelanggaran initialState)
        {
            if (!Enum.IsDefined(typeof(StatusPelanggaran), initialState))
                throw new ArgumentException("Status awal tidak valid.");
            _currentState = initialState;
        }
        public StatusPelanggaran CurrentState
        {
            get => _currentState;
            private set
            {
                if (!Enum.IsDefined(typeof(StatusPelanggaran), value))
                    throw new ArgumentException("Status tidak valid.");
                _currentState = value;
            }
        }
        public StatusPelanggaran GetNextState(StatusPelanggaran prevState, Trigger trigger)
        {
            if (!Enum.IsDefined(typeof(StatusPelanggaran), prevState) || !Enum.IsDefined(typeof(Trigger), trigger))
                throw new ArgumentException("PrevState atau trigger tidak valid.");

            foreach (var t in transitions)
            {
                if (t.PrevState == prevState && t.Trigger == trigger)
                    return t.NextState;
            }

            throw new InvalidOperationException($"Tidak ada transisi yang cocok untuk {prevState} dengan trigger {trigger}");
        }
        public void Activate(Trigger trigger) => CurrentState = GetNextState(CurrentState, trigger);
    }
}