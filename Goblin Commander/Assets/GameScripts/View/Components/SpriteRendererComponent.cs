using Entitas;
using UnityEngine;

[Game]
public class SpriteRendererComponent : IComponent
{
    public SpriteRenderer Value;
    
    public static implicit operator SpriteRenderer(SpriteRendererComponent spriteRendererComponent)
    {
        return spriteRendererComponent.Value;
    }
}