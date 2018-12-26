using Entitas;

public class SettingsFeature : Feature
{
	public SettingsFeature(Contexts contexts) : base("Settings")
	{
		Add(new InitializeSettingsSystem(contexts));
		Add(new InitializeBeaconsSettingsSystem(contexts));
		Add(new InitializeCharactersSettingsSystem(contexts));
		Add(new InitializeObstaclesSettingsSystem(contexts));
	}
}
