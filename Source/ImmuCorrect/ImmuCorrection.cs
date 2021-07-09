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
        public static void Correct_missing_immu()
        {
            if (Current.Game == null)
            {
                Messages.Message("ImmuCorrect.GameNotLoaded".Translate(), MessageTypeDefOf.RejectInput, false);
                return;
            }

            if (Controller.Settings.AllowReset)
            {
                var num = 0;
                var list = PawnsFinder.All_AliveOrDead.ToList();
                if (list.Count > 0)
                {
                    foreach (var pawn in list)
                    {
                        var list2 = new List<ImmunityRecord>();
                        bool b;
                        if (pawn == null)
                        {
                            b = false;
                        }
                        else
                        {
                            var health = pawn.health;
                            b = health?.immunity != null;
                        }

                        if (!b)
                        {
                            continue;
                        }

                        var list3 = NonPublicFields.ImmunityList(pawn.health.immunity);
                        if (list3.Count > 0)
                        {
                            foreach (var immunityRecord in list3)
                            {
                                var hediffDef = immunityRecord?.hediffDef;
                                if (hediffDef != null &&
                                    DefDatabase<HediffDef>.GetNamed(hediffDef.defName, false) != null)
                                {
                                    list2.Add(immunityRecord);
                                }
                            }
                        }

                        num++;
                        NonPublicFields.ImmunityList(pawn.health.immunity) = list2;
                    }
                }

                Messages.Message("ImmuCorrect.Message".Translate(num.ToString()), MessageTypeDefOf.CautionInput, false);
                return;
            }

            Messages.Message("ImmuCorrect.NotAllow".Translate(), MessageTypeDefOf.RejectInput, false);
        }
    }
}