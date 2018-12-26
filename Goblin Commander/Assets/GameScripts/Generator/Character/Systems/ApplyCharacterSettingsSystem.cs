using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;
using System;

public class ApplyCharacterSettingsSystem : ReactiveSystem<GameEntity> {

    private GameContext gameContext;

    public ApplyCharacterSettingsSystem(Contexts contexts) : base(contexts.game) {}

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.CharacterType);
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasCharacterType;
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (GameEntity characterEntity in entities)
        {
            ApplyCharacterSettings(characterEntity);
        }
    }
    
    public void ApplyCharacterSettings(GameEntity characterEntity)
    {
        CharacterType characterType = characterEntity.characterType.Value;
        CharacterSettings settings = SettingsService.GetCharacterSettings(characterType);
        
        characterEntity.AddMobility(settings.MovementSpeed);
        characterEntity.AddSightRange(settings.SightRange);
        characterEntity.AddAttack(
            settings.AttackPower,
            settings.AttackRange,
            settings.AttackCooldown
        );
        characterEntity.AddHealth(settings.Health);
    }
}