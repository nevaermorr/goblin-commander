using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GlobalSettings", menuName = "Settings/Global")]
public class GlobalSettings : ScriptableObject
{
	[Header("Energy")]
	public float StartingEnergy;
	public float EnergyRecoveryInterval;
	public float EnergyRecoveryAmountOverTime;
	public float EnergyRecoveryAmountOnEnemyHit;
	[Header("Beacons")]
	public BeaconAction DefaultBeaconAction;
}
