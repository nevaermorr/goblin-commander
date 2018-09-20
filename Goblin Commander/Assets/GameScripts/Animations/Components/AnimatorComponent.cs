using Entitas;
using UnityEngine;

[Game]
public class AnimatorComponent : IComponent
{
    public Animator Value;

    public static implicit operator Animator(AnimatorComponent spriteRendererComponent)
    {
        return spriteRendererComponent.Value;
    }
}