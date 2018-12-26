using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class InitializeBeaconsSettingsSystem : IInitializeSystem
{
    public const string BEACONS_SETTINGS_PATH = "Beacons";
    private GameContext gameContext;
    public InitializeBeaconsSettingsSystem(Contexts contexts)
    {
        gameContext = contexts.game;
    }

    public void Initialize()
    {
        LoadBeaconSettings();
        SetDefaultsToGameSettings();
    }

    private void LoadBeaconSettings()
    {
        try
        {
            BeaconSettings[] beaconSettings = SettingsService.GetAllSettings<BeaconSettings>(BEACONS_SETTINGS_PATH);

            Dictionary<BeaconAction, BeaconSettings> beaconSettingsMap = new Dictionary<BeaconAction, BeaconSettings>();
            foreach (BeaconSettings setting in beaconSettings) {
                beaconSettingsMap[setting.Action] = setting;
            }

            gameContext.settingsEntity.AddBeaconsSettings(beaconSettingsMap);
        }
        catch (Exception exception){
            Debug.LogError(string.Format("Error while loading beacons settings: {0}",
            exception.Message));
        }
    }

    private void SetDefaultsToGameSettings()
    {
        BeaconAction currentBeaconAction = gameContext.settingsEntity.globalSettings.Value.DefaultBeaconAction;
        RequestsService.CreateRequestEntity().AddSwitchBeaconActionRequest(currentBeaconAction);
    }
}
