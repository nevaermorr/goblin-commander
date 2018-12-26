//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public GlobalSettingsComponent globalSettings { get { return (GlobalSettingsComponent)GetComponent(GameComponentsLookup.GlobalSettings); } }
    public bool hasGlobalSettings { get { return HasComponent(GameComponentsLookup.GlobalSettings); } }

    public void AddGlobalSettings(GlobalSettings newValue) {
        var index = GameComponentsLookup.GlobalSettings;
        var component = CreateComponent<GlobalSettingsComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceGlobalSettings(GlobalSettings newValue) {
        var index = GameComponentsLookup.GlobalSettings;
        var component = CreateComponent<GlobalSettingsComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveGlobalSettings() {
        RemoveComponent(GameComponentsLookup.GlobalSettings);
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

    static Entitas.IMatcher<GameEntity> _matcherGlobalSettings;

    public static Entitas.IMatcher<GameEntity> GlobalSettings {
        get {
            if (_matcherGlobalSettings == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.GlobalSettings);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherGlobalSettings = matcher;
            }

            return _matcherGlobalSettings;
        }
    }
}