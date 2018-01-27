using UnityEngine;
using Entitas;
using System.Collections.Generic;

public class AssignCharacterSpriteSystem : ReactiveSystem<GameEntity>
{
    private readonly Dictionary<CharacterType, string> CharacterSpritePath 
        = new Dictionary<CharacterType, string>
    {
        {CharacterType.goblin, "Sprites/Characters/goblin"}
    };

    public AssignCharacterSpriteSystem(Contexts contexts) : base(contexts.game)
    {
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CharacterType.Added());
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCharacterType && !entity.hasSprite;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity entity in entities)
        {
            Sprite sprite = Resources.Load<Sprite>(CharacterSpritePath[entity.characterType]);
            entity.AddSprite(sprite);
        }
    }
}