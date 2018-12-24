using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BeaconSettings", menuName = "Settings/Beacon")]
public class BeaconSettings : ScriptableObject
{
	public BeaconAction Action;
	public float Range;
	public float Cost;
}
