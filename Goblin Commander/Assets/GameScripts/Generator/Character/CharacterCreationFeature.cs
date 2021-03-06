﻿using Entitas;

public class CharacterCreationFeature : Feature
{
	public CharacterCreationFeature(Contexts contexts) : base("Character")
    {
        Add(new InitializeCharactersSystem(contexts));
        Add(new GenerateCharacterSystem(contexts));
        Add(new InstantiateCharacterPrefabSystem(contexts));
        Add(new ApplyCharacterSettingsSystem(contexts));
    }
}