using System;
using System.Collections.Generic;
using UnityEngine;
using Verse;

namespace ImmuCorrect
{
	// Token: 0x02000006 RID: 6
	public class Settings : ModSettings
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002260 File Offset: 0x00000460
		public void DoWindowContents(Rect canvas)
		{
			string label = "ImmuCorrect.Reset".Translate();
			float num = 10f;
			Listing_Standard listing_Standard = new Listing_Standard();
			listing_Standard.ColumnWidth = canvas.width;
			listing_Standard.Begin(canvas);
			listing_Standard.Gap(num);
			listing_Standard.CheckboxLabeled("ImmuCorrect.AllowReset".Translate(), ref this.AllowReset, null);
			listing_Standard.Gap(num);
			float posX = 0f;
			float posY = num * 4f;
			if (Widgets.ButtonText(Settings.GetResetRect(40f, canvas.width / 4f, posX, posY), label, true, false, true))
			{
				List<FloatMenuOption> list = new List<FloatMenuOption>();
				list.Add(new FloatMenuOption(label, delegate()
				{
					ImmuCorrection.Correct_missing_immu();
				}, MenuOptionPriority.Default, null, null, 0f, null, null));
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
			Scribe_Values.Look<bool>(ref this.AllowReset, "AllowReset", true, false);
		}

		// Token: 0x04000003 RID: 3
		public bool AllowReset;
	}
}
