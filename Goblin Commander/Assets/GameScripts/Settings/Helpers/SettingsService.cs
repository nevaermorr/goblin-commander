using UnityEngine;

public static class SettingsService
{
    public const string SETTINGS_RESOURCES_COMMON_PATH = "Settings";

    public static T GetSettings<T>(string subPath) where T : Object
    {
        T settings = Resources.Load<T>(SETTINGS_RESOURCES_COMMON_PATH + "/" + subPath);
        if (settings == null) {
            Debug.LogWarning(string.Format("[settings] Settings of type {0} not found", typeof(T).ToString()));
        }
        return settings;
    }
    
    public static T[] GetAllSettings<T>(string subPath) where T : Object
    {
        T[] settings = Resources.LoadAll<T>(SETTINGS_RESOURCES_COMMON_PATH + "/" + subPath);
        if (settings == null || settings.Length == 0) {
            Debug.LogWarning(string.Format("[settings] Settings of type {0} not found", typeof(T).ToString()));
        }
        return settings;
    }

    public static CharacterSettings GetCharacterSettings(CharacterType characterType)
    {
        try
        {
            GameEntity settingsEntity = Contexts.sharedInstance.game.settingsEntity;
            CharacterSettings settings = settingsEntity.charactersSettings.Map[characterType];
            return settings;
        }
        catch (System.Exception exception){
            Debug.LogError(string.Format("Could not find character settings for the type {0}: {1}",
            characterType,
            exception.Message));
        }
        return new CharacterSettings();
    }
}