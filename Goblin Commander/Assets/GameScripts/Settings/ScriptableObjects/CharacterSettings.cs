using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSettings", menuName = "Settings/Characters")]
public class CharacterSettings : ScriptableObject
{
	public CharacterType Character;
	[Header("General")]
	public float MovementSpeed;
	public float SightRange;
	public float Health;
	[Header("Attack")]
	public float AttackPower;
	public float AttackRange;
	public float AttackCooldown;

}
