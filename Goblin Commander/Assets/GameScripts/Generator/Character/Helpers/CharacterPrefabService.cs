using UnityEngine;

public static class CharacterPrefabService
{
    private const string CHARACTERS_PREFABS_DIRECTORY_PATH = "Prefabs/Characters/";

    public static GameObject GetPrefabForType(CharacterType characterType)
    {
        GameObject gameObject;
        gameObject = Resources.Load(GetCharacterPrefabPathForType(characterType))
            as GameObject;
            
        return gameObject;
    }

    // TODO Move it to some kind of scriptable object with prefabs assigned.
    private static string GetCharacterPrefabPathForType(CharacterType characterType)
    {
        string prefabName = "";
        switch (characterType)
        {
            case CharacterType.goblin:
                prefabName = "Goblin";
                break;
        }
        return CHARACTERS_PREFABS_DIRECTORY_PATH + prefabName;
    }
}