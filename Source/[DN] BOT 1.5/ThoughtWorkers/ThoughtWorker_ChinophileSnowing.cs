﻿namespace More_Traits.ThoughtWorkers;

public class ThoughtWorker_ChinophileSnowing : ThoughtWorker
{
    protected override ThoughtState CurrentStateInternal(Pawn p)
    {
        if (!p.Spawned) return false;

        return p.Map.weatherManager.RainRate > 0.25 && p.Map.weatherManager.SnowRate > 0.25;
    }
}
