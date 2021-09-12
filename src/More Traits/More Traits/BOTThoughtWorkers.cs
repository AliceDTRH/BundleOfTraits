﻿using System;
using JetBrains.Annotations;
using RimWorld;
using Verse;

namespace More_Traits
{
	public class ThoughtWorker_Misanthrope : ThoughtWorker
	{
		protected override ThoughtState CurrentSocialStateInternal(Pawn p, Pawn otherPawn)
		{
			return p.RaceProps.Humanlike && otherPawn.RaceProps.Humanlike && RelationsUtility.PawnsKnowEachOther(p, otherPawn);
		}
	}

	public class ThoughtWorker_IsCarryingWeapon : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			return p.equipment.Primary != null;
		}
	}

	public class BOT_ThoughtWorker_PyrophobicOnFire : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			return p.IsBurning();
		}
	}

	public class BOT_ThoughtWorker_Hot : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			float num = p.AmbientTemperature - p.GetStatValue(StatDefOf.ComfyTemperatureMax, true);

			if (p.story.traits.DegreeOfTrait(BOTTraitDefOf.BOT_Temperature_Love) == -1)
			{
				//Loves the heat
				if (p.AmbientTemperature > 25f && num < 10f)
                {
					return ThoughtState.ActiveAtStage(4);
				}
				return false;
			} else if (p.story.traits.DegreeOfTrait(BOTTraitDefOf.BOT_Temperature_Love) == 1)
			{
				//Loves the cold
			} else
            {
				return false;
            }
			if (num <= 0f)
			{
				return ThoughtState.Inactive;
			}
			int num2;
			if (num < 10f)
			{
				num2 = 0;
			}
			else if (num < 20f)
			{
				num2 = 1;
			}
			else if (num < 30f)
			{
				num2 = 2;
			}
			else
			{
				num2 = 3;
			}
			if (ModsConfig.IdeologyActive && p.Ideo.HasPrecept(PreceptDefOf.Temperature_Tough))
			{
				num2 -= 2;
			}
			if (num2 >= 0)
			{
				return ThoughtState.ActiveAtStage(num2);
			}
			return ThoughtState.Inactive;
		}
	}

	public class BOT_ThoughtWorker_Cold : ThoughtWorker
	{
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			float num = p.GetStatValue(StatDefOf.ComfyTemperatureMin, true) - p.AmbientTemperature;

			if (p.story.traits.DegreeOfTrait(BOTTraitDefOf.BOT_Temperature_Love) == -1)
			{
				//Loves the heat
			}
			else if (p.story.traits.DegreeOfTrait(BOTTraitDefOf.BOT_Temperature_Love) == 1)
			{
				//Loves the cold
				if (p.AmbientTemperature < 5f && num < 10f)
				{
					return ThoughtState.ActiveAtStage(4);
				}
				return false;
			}
			else
			{
				return false;
			}
			if (num <= 0f)
			{
				return ThoughtState.Inactive;
			}
			int num2;
			if (num < 10f)
			{
				num2 = 0;
			}
			else if (num < 20f)
			{
				num2 = 1;
			}
			else if (num < 30f)
			{
				num2 = 2;
			}
			else
			{
				num2 = 3;
			}
			if (ModsConfig.IdeologyActive && p.Ideo.HasPrecept(PreceptDefOf.Temperature_Tough))
			{
				num2 -= 2;
			}
			if (num2 >= 0)
			{
				return ThoughtState.ActiveAtStage(num2);
			}
			return ThoughtState.Inactive;
		}
	}

	public class BOT_ThoughtWorker_PyrophobicBurned : ThoughtWorker
    {
		protected override ThoughtState CurrentStateInternal(Pawn p)
		{
			if (p.health.hediffSet.GetFirstHediffOfDef(HediffDefOf.Burn) != null)
			{
				if (ModsConfig.IdeologyActive && p.Ideo.HasPrecept(BOTPreceptDefOf.Pain_Idealized))
				{
					return ThoughtState.ActiveAtStage(1);
				}
				return ThoughtState.ActiveAtStage(0);
			}
			return false;
		}
	}
}