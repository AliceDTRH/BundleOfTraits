﻿using HarmonyLib;
using More_Traits.HarmonyPatching.Patches;
using RimWorld;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace More_Traits.HarmonyPatching
{
    [StaticConstructorOnStartup]
    public static class HarmonyPatcher
    {
        static HarmonyPatcher()
        {
            Harmony harmony = new Harmony("BOT_Patcher");
            harmony.Patch(AccessTools.Method(typeof(Toils_Ingest), nameof(Toils_Ingest.FinalizeIngest)), postfix: new HarmonyMethod(typeof(EclecticPalate_FinalizeIngestPatch), nameof(EclecticPalate_FinalizeIngestPatch.EclecticPalate_Postfix)));
        }
    }
}
