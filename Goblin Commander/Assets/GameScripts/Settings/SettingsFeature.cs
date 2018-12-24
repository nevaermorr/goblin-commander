using Entitas;

public class SettingsFeature : Feature
{
	public SettingsFeature(Contexts contexts) : base("Settings")
	{
		Add(new InitializeSettingsSystem(contexts));
		Add(new InitializeBeaconsSettingsSystem(contexts));
	}
}
