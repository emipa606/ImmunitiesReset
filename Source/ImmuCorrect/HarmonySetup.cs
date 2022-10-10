using System.Reflection;
using HarmonyLib;
using Verse;

namespace ImmuCorrect;

[StaticConstructorOnStartup]
public static class HarmonySetup
{
    static HarmonySetup()
    {
        new Harmony("ImmuCorrect.Pelador").PatchAll(Assembly.GetExecutingAssembly());
    }
}