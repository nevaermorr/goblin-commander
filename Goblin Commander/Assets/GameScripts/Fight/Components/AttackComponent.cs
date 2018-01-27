using UnityEngine;
using Entitas;

[Game]
public class AttackComponent : IComponent
{
    public float Power;
    public float Range;
}

public partial class GameEntity
{
    public void Attack(GameEntity target)
    {
        Debug.Assert(this.hasAttack);
        Debug.Log("attack for " + this.attack.Power);
    }
}