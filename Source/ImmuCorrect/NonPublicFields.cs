using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace ImmuCorrect
{
    // Token: 0x02000005 RID: 5
    [StaticConstructorOnStartup]
    public static class NonPublicFields
    {
        // Token: 0x04000002 RID: 2
        public static AccessTools.FieldRef<ImmunityHandler, List<ImmunityRecord>> ImmunityList =
            AccessTools.FieldRefAccess<ImmunityHandler, List<ImmunityRecord>>("immunityList");
    }
}