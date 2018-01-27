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

    public void DeliverTo(GameEntity targetEntity)
    {
        if (!IsReady())
        {
            return;
        }
        Debug.Log("attack for " + this.Power);
        cooldownEntity.ReplaceCooldown(CooldownTime);

    }

    private bool IsReady()
    {
        return !cooldownEntity.hasCooldown;
    }
}