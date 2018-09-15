using Entitas;

public class CombatCleanupFeature : Feature
{
    public CombatCleanupFeature(Contexts contexts) : base("Combat cleanup")
    {
        Add(new IgnoreDeadEnemySystem(contexts));
    }
}