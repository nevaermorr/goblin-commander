using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBeaconAction : MonoBehaviour {

	[SerializeField]
	BeaconAction Action;

	public void Execute()
	{
		RequestsService.CreateRequestEntity().AddSwitchBeaconActionRequest(Action);
	}
}
