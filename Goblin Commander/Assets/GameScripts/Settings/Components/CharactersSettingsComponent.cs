using System.Collections.Generic;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Game]
public class CharactersSettingsComponent : IComponent {
    public Dictionary<CharacterType, CharacterSettings> Map;
}