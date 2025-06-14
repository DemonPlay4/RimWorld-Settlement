using Verse;
using System.Collections.Generic;

namespace SimulatedSettlements
{
    /// <summary>
    /// World component that stores the list of all simulated settlements
    /// and handles saving/loading.
    /// </summary>
    public class WorldComponent_SimulatedColonies : WorldComponent
    {
        public List<SimulatedSettlement> settlements = new List<SimulatedSettlement>();

        public WorldComponent_SimulatedColonies(World world) : base(world) { }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Collections.Look(ref settlements, "settlements", LookMode.Deep);
        }

        public void AddSettlement(SimulatedSettlement settlement)
        {
            settlements.Add(settlement);
        }
    }
}
