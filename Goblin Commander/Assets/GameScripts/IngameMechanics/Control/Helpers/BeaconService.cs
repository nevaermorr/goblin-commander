using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class BeaconService
{
    private static BeaconSettings GetBeaconSettings(BeaconAction action)
    {
        try
        {
            return Contexts.sharedInstance.game.settingsEntity.beaconsSettings.Map[action];
        }
        catch (Exception exception){
            Debug.LogError(string.Format("Could not find proper settings for beacon action {0}: {1}",
            action,
            exception.Message));
        }
        return null;
    }

    public static float GetDefaultRangeForAction(BeaconAction action)
    {
        return GetBeaconSettings(action).Range;
    }

    public static float GetDefaultCostForAction(BeaconAction action)
    {
        return GetBeaconSettings(action).Cost;
    }

    public static GameEntity[] GetMobileCharacterEntitiesInRange(GameEntity beaconEntity)
    {
        return MovementService.GetAllMobileCharacterEntities()
        .Where(entity => entity.position.IsInRangeOf(beaconEntity.position, beaconEntity.beacon.Range)).ToArray();
    }
}