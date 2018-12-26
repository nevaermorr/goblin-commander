using Entitas;
using UnityEngine;

[Game]
public class GenerateCharacterRequestComponent : IComponent
{
    public Vector2 Position;
    public Faction Faction;
    public CharacterType CharacterType;
}