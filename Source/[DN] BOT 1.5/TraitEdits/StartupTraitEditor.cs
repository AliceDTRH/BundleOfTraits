﻿using More_Traits.DefOfs;

namespace More_Traits.TraitEdits;

[StaticConstructorOnStartup]
public static class StartupTraitEditor
{
    static StartupTraitEditor()
    {
        BOT_TraitDefOf.BOT_Apathetic.DataAtDegree(0).disallowedInspirations = new(DefDatabase<InspirationDef>.AllDefsListForReading);
        BOT_TraitDefOf.BOT_Apathetic.conflictingPassions = new(DefDatabase<SkillDef>.AllDefsListForReading);
    }
}
