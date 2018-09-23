using Entitas;

public class CombatFeature : Feature
{
    public CombatFeature(Contexts contexts) : base("Combat")
    {
        Add(new ChooseEnemySystem(contexts));
        Add(new ScareSystem(contexts));
        Add(new StopBeingScaredSystem(contexts));
        Add(new FollowEnemySystem(contexts));
        Add(new AttackCurrentEnemySystem(contexts));
        Add(new OrientateWhenFightingSystem(contexts));
    }
}