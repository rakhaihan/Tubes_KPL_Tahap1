using System;
using Tubes_Console.Model;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Tubes_Console.Automata
{
    public class PelanggaranStateMachine
    {
        private struct Transisi
        {
            public StatusPelanggaran PrevState { get; }
            public StatusPelanggaran NextState { get; }
            public Trigger Trigger { get; }

            public Transisi(StatusPelanggaran prevState, StatusPelanggaran nextState, Trigger trigger)
            {
                if (!Enum.IsDefined(typeof(StatusPelanggaran), prevState))
                    throw new ArgumentException("PrevState tidak valid.");

                if (!Enum.IsDefined(typeof(StatusPelanggaran), nextState))
                    throw new ArgumentException("NextState tidak valid.");

                if (!Enum.IsDefined(typeof(Trigger), trigger))
                    throw new ArgumentException("Trigger tidak valid.");

                PrevState = prevState;
                NextState = nextState;
                Trigger = trigger;
            }
        }

        private readonly List<Transisi> transitions = new List<Transisi>
        {
            new Transisi(StatusPelanggaran.DILAPORKAN, StatusPelanggaran.DISETUJUI, Trigger.SETUJUI),
            new Transisi(StatusPelanggaran.DISETUJUI, StatusPelanggaran.DIBERI_SANKSI, Trigger.BERI_SANKSI),
            new Transisi(StatusPelanggaran.DIBERI_SANKSI, StatusPelanggaran.SELESAI, Trigger.SELESAIKAN)
        };

        private StatusPelanggaran currentState = StatusPelanggaran.DILAPORKAN;

        public StatusPelanggaran CurrentState
        {
            get => currentState;
            private set
            {
                if (!Enum.IsDefined(typeof(StatusPelanggaran), value))
                    throw new ArgumentException("State tidak valid.");

                currentState = value;
            }
        }

        public StatusPelanggaran GetNextState(StatusPelanggaran prevState, Trigger trigger)
        {
            if (!Enum.IsDefined(typeof(StatusPelanggaran), prevState))
                throw new ArgumentException(nameof(prevState), "PrevState tidak valid.");

            if (!Enum.IsDefined(typeof(Trigger), trigger))
                throw new ArgumentException(nameof(trigger), "Trigger tidak valid.");

            foreach (var t in transitions)
            {
                if (t.PrevState == prevState && t.Trigger == trigger)
                {
                    Debug.Assert(Enum.IsDefined(typeof(StatusPelanggaran), t.NextState), "NextState harus valid.");
                    return t.NextState;
                }
            }

            var validTriggers = GetValidTriggers(prevState);
            throw new InvalidOperationException(
                $"Transisi tidak tersedia dari state '{prevState}' dengan trigger '{trigger}'.\n" +
                $"Trigger yang valid dari state ini: {string.Join(", ", validTriggers)}");
        }

        public void Activate(Trigger trigger)
        {
            var next = GetNextState(CurrentState, trigger);
            CurrentState = next;

            Debug.Assert(Enum.IsDefined(typeof(StatusPelanggaran), CurrentState), "CurrentState harus valid setelah transisi.");
        }

        public IEnumerable<Trigger> GetValidTriggers(StatusPelanggaran state)
        {
            return transitions
                .Where(t => t.PrevState == state)
                .Select(t => t.Trigger);
        }
    }
}
