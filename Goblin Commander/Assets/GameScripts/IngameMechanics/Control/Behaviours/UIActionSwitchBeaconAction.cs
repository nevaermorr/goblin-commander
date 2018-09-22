using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActionSwitchBeaconAction : MonoBehaviour {

	[SerializeField]
	BeaconAction Action;

	public void Execute()
	{
		RequestsService.CreateRequestEntity().AddSwitchBeaconActionRequest(Action);
	}
}
