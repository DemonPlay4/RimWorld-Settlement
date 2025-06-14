using Verse;
using RimWorld;
using UnityEngine;

namespace SimulatedSettlements
{
    /// <summary>
    /// GameComponent responsible for weekly tick updates of settlements.
    /// Handles taxes and random events.
    /// </summary>
    public class GameComponent_TickHandler : GameComponent
    {
        private int tickCounter;

        public GameComponent_TickHandler(Game game) : base() { }

        public override void GameComponentTick()
        {
            tickCounter++;
            if (tickCounter >= GenDate.TicksPerDay * 7)
            {
                tickCounter = 0;
                ProcessWeek();
            }
        }

        private void ProcessWeek()
        {
            var component = Find.World.GetComponent<WorldComponent_SimulatedColonies>();
            foreach (var settlement in component.settlements)
            {
                settlement.morale = Mathf.Clamp01(settlement.morale - 0.01f);
                if (settlement.morale < 0.3f && Rand.Value < 0.1f)
                {
                    Messages.Message($"Rebellion brewing in {settlement.SettlementName}!", MessageTypeDefOf.NegativeEvent);
                }
            }
        }
    }
}
