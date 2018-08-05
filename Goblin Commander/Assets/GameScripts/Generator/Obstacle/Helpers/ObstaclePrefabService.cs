using UnityEngine;

public static class ObstaclePrefabService
{
    private const string CHARACTERS_PREFABS_DIRECTORY_PATH = "Prefabs/Obstacles/";

    public static GameObject GetPrefabForType(ObstacleType obstacleType)
    {
        GameObject gameObject;
        gameObject = Resources.Load(GetObstaclePrefabPathForType(obstacleType))
            as GameObject;
            
        return gameObject;
    }

    // TODO Move it to some kind of scriptable object with prefabs assigned.
    private static string GetObstaclePrefabPathForType(ObstacleType obstacleType)
    {
        string prefabName = "";
        switch (obstacleType)
        {
            case ObstacleType.crate:
                prefabName = "Crate";
                break;
        }
        return CHARACTERS_PREFABS_DIRECTORY_PATH + prefabName;
    }
}