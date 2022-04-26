using UnityEngine;
using System;
using System.Collections.Generic;

[ExecuteInEditMode]
public class ThirdPersonListener : AkGameObj
{
	[SerializeField]
	private Transform player;

	public override Vector3 GetPosition()
	{
		return player.GetComponent<AkGameObj>().GetPosition();
	}
}
