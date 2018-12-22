using System.Collections.Generic;
using System.Linq;

public static class BeaconService
{
    //TODO extract this to scriptable oject or something.
    private static Dictionary<BeaconAction, float> DEFAULT_BEACON_RANGES = new Dictionary<BeaconAction, float>
    {
        {BeaconAction.Summon, 5f},
        {BeaconAction.Scare, 1f}
    };

    private static Dictionary<BeaconAction, float> DEFAULT_BEACON_COSTS = new Dictionary<BeaconAction, float>
    {
        {BeaconAction.Summon, 1f},
        {BeaconAction.Scare, 3f}
    };

    public static float GetDefaultRangeForAction(BeaconAction action)
    {
        if (!DEFAULT_BEACON_RANGES.ContainsKey(action)){
            return 0f;
        }
        return DEFAULT_BEACON_RANGES[action];
    }

    public static float GetDefaultCostForAction(BeaconAction action)
    {
        if (!DEFAULT_BEACON_COSTS.ContainsKey(action)){
            return 0f;
        }
        return DEFAULT_BEACON_COSTS[action];
    }

    public static GameEntity[] GetMobileCharacterEntitiesInRange(GameEntity beaconEntity)
    {
        return MovementService.GetAllMobileCharacterEntities()
        .Where(entity => entity.position.IsInRangeOf(beaconEntity.position, beaconEntity.beacon.Range)).ToArray();
    }
}