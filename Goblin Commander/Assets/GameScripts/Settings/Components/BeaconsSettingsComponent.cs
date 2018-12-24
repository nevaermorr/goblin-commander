using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class BeaconsSettingsComponent : IComponent {
    public Dictionary<BeaconAction, BeaconSettings> Map;
}