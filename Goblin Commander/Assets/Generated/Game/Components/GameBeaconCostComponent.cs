//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BeaconCostComponent beaconCost { get { return (BeaconCostComponent)GetComponent(GameComponentsLookup.BeaconCost); } }
    public bool hasBeaconCost { get { return HasComponent(GameComponentsLookup.BeaconCost); } }

    public void AddBeaconCost(float newValue) {
        var index = GameComponentsLookup.BeaconCost;
        var component = CreateComponent<BeaconCostComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceBeaconCost(float newValue) {
        var index = GameComponentsLookup.BeaconCost;
        var component = CreateComponent<BeaconCostComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveBeaconCost() {
        RemoveComponent(GameComponentsLookup.BeaconCost);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherBeaconCost;

    public static Entitas.IMatcher<GameEntity> BeaconCost {
        get {
            if (_matcherBeaconCost == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BeaconCost);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBeaconCost = matcher;
            }

            return _matcherBeaconCost;
        }
    }
}
