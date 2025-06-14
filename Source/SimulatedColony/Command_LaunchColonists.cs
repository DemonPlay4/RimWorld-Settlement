using RimWorld;
using Verse;
using Verse.Sound;

namespace SimulatedSettlements
{
    /// <summary>
    /// Command to launch two colonists on an expedition to found a new settlement.
    /// This is simplified and does not actually spawn caravans.
    /// </summary>
    public class Command_LaunchColonists : Command
    {
        public Pawn colonistA;
        public Pawn colonistB;
        public int targetTile;

        public override void ProcessInput(UnityEngine.Event ev)
        {
            base.ProcessInput(ev);
            SoundDefOf.Tick_High.PlayOneShotOnCamera();

            var settlement = new SimulatedSettlement(colonistA.LabelShortCap + " & " + colonistB.LabelShortCap, targetTile);
            Find.World.GetComponent<WorldComponent_SimulatedColonies>().AddSettlement(settlement);

            Messages.Message($"{settlement.SettlementName} founded at tile {targetTile}.", MessageTypeDefOf.PositiveEvent);
            colonistA.Destroy();
            colonistB.Destroy();
        }
    }
}
