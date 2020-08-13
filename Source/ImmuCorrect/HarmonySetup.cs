using System;
using System.Reflection;
using HarmonyLib;
using Verse;

namespace ImmuCorrect
{
	// Token: 0x02000004 RID: 4
	[StaticConstructorOnStartup]
	public static class HarmonySetup
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002238 File Offset: 0x00000438
		static HarmonySetup()
		{
			new Harmony("ImmuCorrect.Pelador").PatchAll(Assembly.GetExecutingAssembly());
		}
	}
}
