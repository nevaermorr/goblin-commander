using System.Linq;
using UnityEngine;

public static class MovementService
{
    public static GameEntity[] GetAllMobileCharacterEntities()
    {
        return Contexts.sharedInstance.game.GetGroup(
            GameMatcher.AllOf(
                GameMatcher.Position,
                GameMatcher.CharacterType,
                GameMatcher.Mobility
            )).GetEntities();
    }
}