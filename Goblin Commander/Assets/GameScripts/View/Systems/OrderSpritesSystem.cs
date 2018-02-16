using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class OrderSpritesSystem : IExecuteSystem
{
    private IGroup<GameEntity> spriteEntities;
    public OrderSpritesSystem(Contexts contexts)
    {
        spriteEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.SpriteRenderer, GameMatcher.GameObject));
    }
    public void Execute()
    {
        foreach (var spriteEntity in spriteEntities.GetEntities())
        {
            SetSpriteOrder(spriteEntity.spriteRenderer);
        }
    }

    private void SetSpriteOrder(SpriteRenderer spriteRenderer)
    {
        var position = Camera.main.WorldToScreenPoint(spriteRenderer.transform.position);
        int order = -(int) (
            GetScreenPixelsToMaxIntModifier()
            * (((position.y - 1) * Screen.width)
                + position.x));
        spriteRenderer.sortingOrder = order;
    }

    private float GetScreenPixelsToMaxIntModifier()
    {
        float modifier = 1;
        int pixelCount = Screen.width * Screen.height;
        if (pixelCount > short.MaxValue)
        {
            modifier = short.MaxValue / (float)pixelCount; 
        }
        return modifier;
    }
}