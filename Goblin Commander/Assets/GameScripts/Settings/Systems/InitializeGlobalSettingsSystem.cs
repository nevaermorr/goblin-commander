using Entitas;
using UnityEngine;

public class InitializeSettingsSystem : IInitializeSystem
{
    public const string GLOBAL_SETTINGS_PATH = "GlobalSettings";
    private GameContext gameContext;
    private GameEntity settingsEntity;
    public InitializeSettingsSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        SetUpSettingsEntity();
        LoadGlobalSettings();
    }

    private void SetUpSettingsEntity()
    {
        settingsEntity = gameContext.CreateEntity();
        settingsEntity.isSettings = true;
    }

    private void LoadGlobalSettings()
    {
        try
        {
            GlobalSettings globalSettings = SettingsService.GetSettings<GlobalSettings>(GLOBAL_SETTINGS_PATH);
            settingsEntity.AddGlobalSettings(globalSettings);
        }
        catch {}
    }
}
