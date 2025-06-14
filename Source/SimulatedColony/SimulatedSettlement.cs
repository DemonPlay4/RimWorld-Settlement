using RimWorld;
using Verse;
using System.Collections.Generic;

namespace SimulatedSettlements
{
    /// <summary>
    /// Data container for a simulated settlement that exists only on the world map.
    /// Stores morale, population and simple resource stockpiles.
    /// </summary>
    public class SimulatedSettlement : IExposable
    {
        public string SettlementName;
        public int tile = -1;
        public float morale = 1f;
        public int population = 2;
        public string id;
        public Dictionary<string, int> stockpile = new Dictionary<string, int>();
        public string policy = "Neutral";
        public string religion;

        public SimulatedSettlement() { }

        public SimulatedSettlement(string name, int tile)
        {
            this.SettlementName = name;
            this.tile = tile;
            this.id = System.Guid.NewGuid().ToString();
        }

        public void ExposeData()
        {
            Scribe_Values.Look(ref SettlementName, "name");
            Scribe_Values.Look(ref tile, "tile");
            Scribe_Values.Look(ref morale, "morale", 1f);
            Scribe_Values.Look(ref population, "population", 2);
            Scribe_Values.Look(ref id, "id");
            Scribe_Collections.Look(ref stockpile, "stockpile", LookMode.Value, LookMode.Value, ref keysWorkingList, ref valuesWorkingList);
            Scribe_Values.Look(ref policy, "policy", "Neutral");
            Scribe_Values.Look(ref religion, "religion");
        }

        private List<string> keysWorkingList;
        private List<int> valuesWorkingList;
    }
}
