using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class OrderSpritesSystem : IExecuteSystem
{
    private IGroup<GameEntity> spriteEntities;
    public OrderSpritesSystem(Contexts contexts)
    {
        spriteEntities = contexts.game.GetGroup(GameMatcher.SpriteRenderer);
    }
    public void Execute()
    {
        foreach (var spriteEntity in spriteEntities.GetEntities())
        {
            SetSpriteOrder(spriteEntity);
        }
    }

    private void SetSpriteOrder(GameEntity spriteOwner)
    {
        spriteOwner.spriteRenderer.Value.sortingOrder = GetSpriteOrderForScreenPosition(
            Camera.main.WorldToScreenPoint(spriteOwner.position));
    }

    private int GetSpriteOrderForScreenPosition(Vector3 position)
    {
        int order = -(int) (
            SpriteOrderingService.PixelCountToMaxShortModifier
            * (((position.y - 1) * Screen.width)
                + position.x));

        return order;
    }
}