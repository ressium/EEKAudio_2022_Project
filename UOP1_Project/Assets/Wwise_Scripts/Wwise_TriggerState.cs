using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_TriggerState : MonoBehaviour
{
	public static bool reverb_toggler = false;
	[SerializeField] private Wwise_GameStates _music_states;
	[Tooltip("Delay before event changes in seconds")]
	[SerializeField] private float time=0.5f;

	// Start is called before the first frame update
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
		{
			reverb_toggler = !reverb_toggler;
			Debug.LogError("toggler state:" + reverb_toggler);
		}

		if (reverb_toggler)
		{
			
			_music_states.CaveReverbEnableEvent(); }

		if (!reverb_toggler)
		{
			_music_states.CaveReverbDisableEvent(); }
	}

	IEnumerator ExecuteAfterTime(float time)
	{
		yield return new WaitForSeconds(time);

		// Code to execute after the delay
	}
}
