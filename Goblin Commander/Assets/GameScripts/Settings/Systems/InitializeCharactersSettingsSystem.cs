using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitializeCharactersSettingsSystem : IInitializeSystem
{
    public const string CHARATERS_SETTINGS_PATH = "Characters";
    private GameContext gameContext;
    public InitializeCharactersSettingsSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        LoadCharacterSettings();
    }

    private void LoadCharacterSettings()
    {
        try
        {
            CharacterSettings[] charactersSettings 
                = SettingsService.GetAllSettings<CharacterSettings>(CHARATERS_SETTINGS_PATH);

            Dictionary<CharacterType, CharacterSettings> charactersSettingsMap 
                = new Dictionary<CharacterType, CharacterSettings>();

            foreach (CharacterSettings setting in charactersSettings) {
                charactersSettingsMap[setting.Character] = setting;
            }
  
            gameContext.settingsEntity.AddCharactersSettings(charactersSettingsMap);
        }
        catch (Exception exception){
            Debug.LogError(string.Format("Error while loading characters settings: {0}",
            exception.Message));
        }
    }

    private void SetDefaultsToGameSettings()
    {
        BeaconAction currentBeaconAction = gameContext.settingsEntity.globalSettings.Value.DefaultBeaconAction;
        RequestsService.CreateRequestEntity().AddSwitchBeaconActionRequest(currentBeaconAction);
    }
}
