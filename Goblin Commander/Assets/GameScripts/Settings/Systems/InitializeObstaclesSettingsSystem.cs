using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitializeObstaclesSettingsSystem : IInitializeSystem
{
    public const string OBSTACLES_SETTINGS_PATH = "Obstacles";
    private GameContext gameContext;
    public InitializeObstaclesSettingsSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        LoadObstacleSettings();
    }

    private void LoadObstacleSettings()
    {
        try
        {
            ObstacleSettings[] charactersSettings 
                = SettingsService.GetAllSettings<ObstacleSettings>(OBSTACLES_SETTINGS_PATH);

            Dictionary<ObstacleType, ObstacleSettings> obstaclesSettingsMap 
                = new Dictionary<ObstacleType, ObstacleSettings>();

            foreach (ObstacleSettings setting in charactersSettings) {
                obstaclesSettingsMap[setting.Obstacle] = setting;
            }
  
            gameContext.settingsEntity.AddObstaclesSettings(obstaclesSettingsMap);
        }
        catch (Exception exception){
            Debug.LogError(string.Format("Error while loading obstacles settings: {0}",
            exception.Message));
        }
    }
}
