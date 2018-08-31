//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ObstacleTypeComponent obstacleType { get { return (ObstacleTypeComponent)GetComponent(GameComponentsLookup.ObstacleType); } }
    public bool hasObstacleType { get { return HasComponent(GameComponentsLookup.ObstacleType); } }

    public void AddObstacleType(ObstacleType newValue) {
        var index = GameComponentsLookup.ObstacleType;
        var component = CreateComponent<ObstacleTypeComponent>(index);
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceObstacleType(ObstacleType newValue) {
        var index = GameComponentsLookup.ObstacleType;
        var component = CreateComponent<ObstacleTypeComponent>(index);
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveObstacleType() {
        RemoveComponent(GameComponentsLookup.ObstacleType);
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

    static Entitas.IMatcher<GameEntity> _matcherObstacleType;

    public static Entitas.IMatcher<GameEntity> ObstacleType {
        get {
            if (_matcherObstacleType == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ObstacleType);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherObstacleType = matcher;
            }

            return _matcherObstacleType;
        }
    }
}