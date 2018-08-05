using Entitas;

public enum Faction
{
    Player,
    Enemy,
    Neutral,
}

public class FactionComponent : IComponent
{
    public Faction Value;

    public static implicit operator Faction(FactionComponent factionComponent)
    {
        return factionComponent.Value;
    }
}

public partial class GameEntity
{
    public bool IsPlayer
    {
        get
        {
            return this.hasFaction && this.faction == Faction.Player;
        }
    }
    public bool IsEnemy
    {
        get
        {
            return this.hasFaction && this.faction == Faction.Enemy;
        }
    }
    public bool IsNeutral
    {
        get
        {
            return this.hasFaction && this.faction == Faction.Neutral;
        }
    }

    public bool BelongsToFaction(Faction faction)
    {
        return this.hasFaction && this.faction == faction;
    }

    public bool IsHostileTowards(GameEntity entity)
    {
        return this.hasFaction
            && entity.hasFaction
            && this.faction != entity.faction;
    }
}