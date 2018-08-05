using UnityEngine;
using Entitas;

[Game]
public class CharacterControllerComponent : IComponent
{
    public CharacterController Value;

    public static implicit operator CharacterController(CharacterControllerComponent characterControllerComponent)
    {
        return characterControllerComponent.Value;
    }
}