using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class ObstaclesSettingsComponent : IComponent {
    public Dictionary<ObstacleType, ObstacleSettings> Map;
}