using RimWorld;
using Verse;
using UnityEngine;

namespace SimulatedSettlements
{
    public static class SettlementUtils
    {
        /// <summary>
        /// Calculates travel time between two tiles, simplified for demo purposes.
        /// </summary>
        public static int TravelTime(int fromTile, int toTile)
        {
            return Mathf.Max(1, Find.WorldGrid.TraversalDistanceBetween(fromTile, toTile) / 5);
        }
    }
}
