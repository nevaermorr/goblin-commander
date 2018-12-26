//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentContextApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputContext {

    public InputEntity inputStateEntity { get { return GetGroup(InputMatcher.InputState).GetSingleEntity(); } }

    public bool isInputState {
        get { return inputStateEntity != null; }
        set {
            var entity = inputStateEntity;
            if (value != (entity != null)) {
                if (value) {
                    CreateEntity().isInputState = true;
                } else {
                    entity.Destroy();
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class InputEntity {

    static readonly InputStateComponent inputStateComponent = new InputStateComponent();

    public bool isInputState {
        get { return HasComponent(InputComponentsLookup.InputState); }
        set {
            if (value != isInputState) {
                var index = InputComponentsLookup.InputState;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : inputStateComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
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
public sealed partial class InputMatcher {

    static Entitas.IMatcher<InputEntity> _matcherInputState;

    public static Entitas.IMatcher<InputEntity> InputState {
        get {
            if (_matcherInputState == null) {
                var matcher = (Entitas.Matcher<InputEntity>)Entitas.Matcher<InputEntity>.AllOf(InputComponentsLookup.InputState);
                matcher.componentNames = InputComponentsLookup.componentNames;
                _matcherInputState = matcher;
            }

            return _matcherInputState;
        }
    }
}