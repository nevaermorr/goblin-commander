using UnityEngine;
using Entitas;

public class CooldownSystem : IExecuteSystem
{
    private GameContext gameContext;
    private IGroup<GameEntity> cooldowns;

    public CooldownSystem(Contexts contexts)
    {
        gameContext = contexts.game;
        cooldowns = gameContext.GetGroup(GameMatcher.Cooldown);
    }

    public void Execute()
    {
        foreach (var cooldownEntity in cooldowns.GetEntities())
        {
             cooldownEntity.cooldown.ReportTimePassed(Time.deltaTime);
             if (cooldownEntity.cooldown.IsReady())
             {
                 cooldownEntity.RemoveCooldown();
             }
        }
    }
}
