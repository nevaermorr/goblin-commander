using Entitas;

public class FightFeature : Feature
{
    public FightFeature(Contexts contexts) : base("Fight")
    {
        Add(new ChooseEnemySystem(contexts));
        Add(new FollowEnemySystem(contexts));
        Add(new AttackCurrentEnemySystem(contexts));
        Add(new DamageSystem(contexts));
    }
}