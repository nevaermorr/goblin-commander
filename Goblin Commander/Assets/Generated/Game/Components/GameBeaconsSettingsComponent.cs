//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public BeaconsSettingsComponent beaconsSettings { get { return (BeaconsSettingsComponent)GetComponent(GameComponentsLookup.BeaconsSettings); } }
    public bool hasBeaconsSettings { get { return HasComponent(GameComponentsLookup.BeaconsSettings); } }

    public void AddBeaconsSettings(System.Collections.Generic.Dictionary<BeaconAction, BeaconSettings> newMap) {
        var index = GameComponentsLookup.BeaconsSettings;
        var component = CreateComponent<BeaconsSettingsComponent>(index);
        component.Map = newMap;
        AddComponent(index, component);
    }

    public void ReplaceBeaconsSettings(System.Collections.Generic.Dictionary<BeaconAction, BeaconSettings> newMap) {
        var index = GameComponentsLookup.BeaconsSettings;
        var component = CreateComponent<BeaconsSettingsComponent>(index);
        component.Map = newMap;
        ReplaceComponent(index, component);
    }

    public void RemoveBeaconsSettings() {
        RemoveComponent(GameComponentsLookup.BeaconsSettings);
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

    static Entitas.IMatcher<GameEntity> _matcherBeaconsSettings;

    public static Entitas.IMatcher<GameEntity> BeaconsSettings {
        get {
            if (_matcherBeaconsSettings == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.BeaconsSettings);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherBeaconsSettings = matcher;
            }

            return _matcherBeaconsSettings;
        }
    }
}
