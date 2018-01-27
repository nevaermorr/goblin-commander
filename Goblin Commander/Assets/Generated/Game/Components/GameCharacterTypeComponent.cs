//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CharacterTypeComponent characterType { get { return (CharacterTypeComponent)GetComponent(GameComponentsLookup.CharacterType); } }
    public bool hasCharacterType { get { return HasComponent(GameComponentsLookup.CharacterType); } }

    public void AddCharacterType(CharacterType newValue) {
        var index = GameComponentsLookup.CharacterType;
        var component = CreateComponent<CharacterTypeComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCharacterType(CharacterType newValue) {
        var index = GameComponentsLookup.CharacterType;
        var component = CreateComponent<CharacterTypeComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCharacterType() {
        RemoveComponent(GameComponentsLookup.CharacterType);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherCharacterType;

    public static Entitas.IMatcher<GameEntity> CharacterType {
        get {
            if (_matcherCharacterType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CharacterType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCharacterType = matcher;
            }

            return _matcherCharacterType;
        }
    }
}