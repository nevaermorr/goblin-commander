//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CharactersSettingsComponent charactersSettings { get { return (CharactersSettingsComponent)GetComponent(GameComponentsLookup.CharactersSettings); } }
    public bool hasCharactersSettings { get { return HasComponent(GameComponentsLookup.CharactersSettings); } }

    public void AddCharactersSettings(System.Collections.Generic.Dictionary<CharacterType, CharacterSettings> newMap) {
        var index = GameComponentsLookup.CharactersSettings;
        var component = CreateComponent<CharactersSettingsComponent>(index);
        component.Map = newMap;
        AddComponent(index, component);
    }

    public void ReplaceCharactersSettings(System.Collections.Generic.Dictionary<CharacterType, CharacterSettings> newMap) {
        var index = GameComponentsLookup.CharactersSettings;
        var component = CreateComponent<CharactersSettingsComponent>(index);
        component.Map = newMap;
        ReplaceComponent(index, component);
    }

    public void RemoveCharactersSettings() {
        RemoveComponent(GameComponentsLookup.CharactersSettings);
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

    static Entitas.IMatcher<GameEntity> _matcherCharactersSettings;

    public static Entitas.IMatcher<GameEntity> CharactersSettings {
        get {
            if (_matcherCharactersSettings == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharactersSettings);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharactersSettings = matcher;
            }

            return _matcherCharactersSettings;
        }
    }
}
