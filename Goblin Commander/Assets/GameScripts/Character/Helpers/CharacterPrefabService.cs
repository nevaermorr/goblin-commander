using UnityEngine;

public static class CharacterPrefabService
{
    private const string CHARACTERS_PREFABS_DIRECTORY_PATH = "Prefabs/Characters/";

    public static GameObject GetCharacterPrefabForType(CharacterType characterType)
    {
        GameObject gameObject;
        gameObject = Resources.Load(GetCharacterPrefabPathForType(characterType))
            as GameObject;
            
        return gameObject;
    }

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