using System.Collections.Generic;
using HarmonyLib;
using Verse;

namespace ImmuCorrect;

[StaticConstructorOnStartup]
public static class NonPublicFields
{
    public static readonly AccessTools.FieldRef<ImmunityHandler, List<ImmunityRecord>> ImmunityList =
        AccessTools.FieldRefAccess<ImmunityHandler, List<ImmunityRecord>>("immunityList");
}