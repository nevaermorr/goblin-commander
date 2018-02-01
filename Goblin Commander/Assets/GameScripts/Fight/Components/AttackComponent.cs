using UnityEngine;
using Entitas;

[Game]
public class AttackComponent : IComponent
{
    public float Power;
    public float Range;
    public float CooldownTime;
    private GameEntity cooldownEntity;

    public AttackComponent()
    {
        cooldownEntity = Contexts.sharedInstance.game.CreateEntity();
    }

    public void StartCoolDown()
    {
        cooldownEntity.ReplaceCooldown(CooldownTime);
    }

    public bool IsReady()
    {
        return !cooldownEntity.hasCooldown;
    }
}