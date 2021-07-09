using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ImmuCorrect
{
    // Token: 0x02000006 RID: 6
    public class Settings : ModSettings
    {
        // Token: 0x04000003 RID: 3
        public bool AllowReset;

        // Token: 0x06000008 RID: 8 RVA: 0x00002260 File Offset: 0x00000460
        public void DoWindowContents(Rect canvas)
        {
            string label = "ImmuCorrect.Reset".Translate();
            var num = 10f;
            var listing_Standard = new Listing_Standard {ColumnWidth = canvas.width};
            listing_Standard.Begin(canvas);
            listing_Standard.Gap(num);
            listing_Standard.CheckboxLabeled("ImmuCorrect.AllowReset".Translate(), ref AllowReset);
            listing_Standard.Gap(num);
            var posX = 0f;
            var posY = num * 4f;
            if (Widgets.ButtonText(GetResetRect(40f, canvas.width / 4f, posX, posY), label, true, false))
            {
                var list = new List<FloatMenuOption>
                {
                    new FloatMenuOption(label, ImmuCorrection.Correct_missing_immu)
                };
                Find.WindowStack.Add(new FloatMenu(list));
            }

            listing_Standard.Gap(num);
            listing_Standard.End();
        }

        // Token: 0x06000009 RID: 9 RVA: 0x00002352 File Offset: 0x00000552
        public static Rect GetResetRect(float height, float width, float posX, float posY)
        {
            return new Rect(posX, posY, width, height);
        }

        // Token: 0x0600000A RID: 10 RVA: 0x0000235D File Offset: 0x0000055D
        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref AllowReset, "AllowReset", true);
        }
    }
}