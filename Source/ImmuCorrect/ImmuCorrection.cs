using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;
using Verse;

namespace ImmuCorrect
{
	// Token: 0x02000003 RID: 3
	public class ImmuCorrection
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002084 File Offset: 0x00000284
		public unsafe static void Correct_missing_immu()
		{
			if (Current.Game == null)
			{
				Messages.Message("ImmuCorrect.GameNotLoaded".Translate(), MessageTypeDefOf.RejectInput, false);
				return;
			}
			if (Controller.Settings.AllowReset)
			{
				int num = 0;
				List<Pawn> list = PawnsFinder.All_AliveOrDead.ToList<Pawn>();
				if (list.Count > 0)
				{
					foreach (Pawn pawn in list)
					{
						List<ImmunityRecord> list2 = new List<ImmunityRecord>();
						bool flag;
						if (pawn == null)
						{
							flag = (null != null);
						}
						else
						{
							Pawn_HealthTracker health = pawn.health;
							flag = ((health?.immunity) != null);
						}
						if (flag)
						{
							List<ImmunityRecord> list3 = NonPublicFields.ImmunityList.Invoke(pawn.health.immunity);
							if (list3.Count > 0)
							{
								foreach (ImmunityRecord immunityRecord in list3)
								{
									HediffDef hediffDef = immunityRecord?.hediffDef;
									if (hediffDef != null && DefDatabase<HediffDef>.GetNamed(hediffDef?.defName, false) != null)
									{
										list2.Add(immunityRecord);
									}
								}
							}
							num++;
							NonPublicFields.ImmunityList.Invoke(pawn.health.immunity) = list2;
						}
					}
				}
				Messages.Message("ImmuCorrect.Message".Translate(num.ToString()), MessageTypeDefOf.CautionInput, false);
				return;
			}
			Messages.Message("ImmuCorrect.NotAllow".Translate(), MessageTypeDefOf.RejectInput, false);
		}
	}
}
