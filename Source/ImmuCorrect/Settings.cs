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
        var num = 10f;
        var listing_Standard = new Listing_Standard { ColumnWidth = canvas.width };
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

        if (Controller.currentVersion != null)
        {
            listing_Standard.Gap(50f);
            GUI.contentColor = Color.gray;
            listing_Standard.Label("ImmuCorrect.Version".Translate(Controller.currentVersion));
            GUI.contentColor = Color.white;
        }

        listing_Standard.Gap(num);
        listing_Standard.End();
    }

    public static Rect GetResetRect(float height, float width, float posX, float posY)
    {
        return new Rect(posX, posY, width, height);
    }

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Values.Look(ref AllowReset, "AllowReset", true);
    }
}