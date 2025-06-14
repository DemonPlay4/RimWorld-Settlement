using RimWorld;
using Verse;
using UnityEngine;
using System.Text;

namespace SimulatedSettlements
{
    /// <summary>
    /// Window that lists all simulated settlements and allows basic management.
    /// </summary>
    public class Dialog_SettlementManager : Window
    {
        public override Vector2 InitialSize => new Vector2(600f, 400f);

        public Dialog_SettlementManager()
        {
            forcePause = true;
            doCloseX = true;
        }

        public override void DoWindowContents(Rect inRect)
        {
            var component = Find.World.GetComponent<WorldComponent_SimulatedColonies>();
            float y = 0f;
            foreach (var settlement in component.settlements)
            {
                var rect = new Rect(0, y, inRect.width, 40f);
                if (Widgets.ButtonText(rect, $"{settlement.SettlementName} (Morale: {settlement.morale:0.##})"))
                {
                    Find.WindowStack.Add(new Dialog_SettlementOptions(settlement));
                }
                y += 45f;
            }
        }
    }

    /// <summary>
    /// Simple detail window for a single settlement.
    /// </summary>
    public class Dialog_SettlementOptions : Window
    {
        private SimulatedSettlement settlement;
        public override Vector2 InitialSize => new Vector2(400f, 300f);

        public Dialog_SettlementOptions(SimulatedSettlement settlement)
        {
            this.settlement = settlement;
            forcePause = true;
            doCloseX = true;
        }

        public override void DoWindowContents(Rect inRect)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Name: {settlement.SettlementName}");
            sb.AppendLine($"Population: {settlement.population}");
            sb.AppendLine($"Morale: {settlement.morale:0.##}");
            sb.AppendLine($"Policy: {settlement.policy}");
            Widgets.Label(inRect, sb.ToString());
        }
    }
}
