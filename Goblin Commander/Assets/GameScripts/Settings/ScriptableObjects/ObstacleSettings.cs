using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObstacleSettings", menuName = "Settings/Obstacles")]
public class ObstacleSettings : ScriptableObject
{
	public ObstacleType Obstacle;
	public GameObject Prefab;

}
