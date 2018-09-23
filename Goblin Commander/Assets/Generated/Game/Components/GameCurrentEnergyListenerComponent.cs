//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public CurrentEnergyListenerComponent currentEnergyListener { get { return (CurrentEnergyListenerComponent)GetComponent(GameComponentsLookup.CurrentEnergyListener); } }
    public bool hasCurrentEnergyListener { get { return HasComponent(GameComponentsLookup.CurrentEnergyListener); } }

    public void AddCurrentEnergyListener(System.Collections.Generic.List<ICurrentEnergyListener> newValue) {
        var index = GameComponentsLookup.CurrentEnergyListener;
        var component = CreateComponent<CurrentEnergyListenerComponent>(index);
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceCurrentEnergyListener(System.Collections.Generic.List<ICurrentEnergyListener> newValue) {
        var index = GameComponentsLookup.CurrentEnergyListener;
        var component = CreateComponent<CurrentEnergyListenerComponent>(index);
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveCurrentEnergyListener() {
        RemoveComponent(GameComponentsLookup.CurrentEnergyListener);
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

    static Entitas.IMatcher<GameEntity> _matcherCurrentEnergyListener;

    public static Entitas.IMatcher<GameEntity> CurrentEnergyListener {
        get {
            if (_matcherCurrentEnergyListener == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.CurrentEnergyListener);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherCurrentEnergyListener = matcher;
            }

            return _matcherCurrentEnergyListener;
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public void AddCurrentEnergyListener(ICurrentEnergyListener value) {
        var listeners = hasCurrentEnergyListener
            ? currentEnergyListener.value
            : new System.Collections.Generic.List<ICurrentEnergyListener>();
        listeners.Add(value);
        ReplaceCurrentEnergyListener(listeners);
    }

    public void RemoveCurrentEnergyListener(ICurrentEnergyListener value, bool removeComponentWhenEmpty = true) {
        var listeners = currentEnergyListener.value;
        listeners.Remove(value);
        if (removeComponentWhenEmpty && listeners.Count == 0) {
            RemoveCurrentEnergyListener();
        } else {
            ReplaceCurrentEnergyListener(listeners);
        }
    }
}
