using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ImmuCorrect;

public class Settings : ModSettings
{
    public bool AllowReset;

    public void DoWindowContents(Rect canvas)
    {
        string label = "ImmuCorrect.Reset".Translate();
        const float num = 10f;
        var listingStandard = new Listing_Standard { ColumnWidth = canvas.width };
        listingStandard.Begin(canvas);
        listingStandard.Gap(num);
        listingStandard.CheckboxLabeled("ImmuCorrect.AllowReset".Translate(), ref AllowReset);
        listingStandard.Gap(num);
        const float posX = 0f;
        const float posY = num * 4f;
        if (Widgets.ButtonText(getResetRect(40f, canvas.width / 4f, posX, posY), label, true, false))
        {
            var list = new List<FloatMenuOption>
            {
                new(label, ImmuCorrection.Correct_missing_immu)
            };
            Find.WindowStack.Add(new FloatMenu(list));
        }

        if (Controller.currentVersion != null)
        {
            listingStandard.Gap(50f);
            GUI.contentColor = Color.gray;
            listingStandard.Label("ImmuCorrect.Version".Translate(Controller.currentVersion));
            GUI.contentColor = Color.white;
        }

        listingStandard.Gap(num);
        listingStandard.End();
    }

    private static Rect getResetRect(float height, float width, float posX, float posY)
    {
        return new Rect(posX, posY, width, height);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref AllowReset, "AllowReset", true);
    }
}