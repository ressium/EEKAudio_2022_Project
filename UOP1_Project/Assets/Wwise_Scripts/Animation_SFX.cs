using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Animation_SFX : MonoBehaviour
{
	bool silence = false;
	[SerializeField] private GameObject GO;


	public void PlayWwiseSFX(string wEvent)
	{
	if (silence) {return;}
	
	if (GO = null) {GO=this.gameObject;}

	
		AkSoundEngine.PostEvent(wEvent,GO);
	//	Debug.Log("Анимация: " + wEvent);
	
	}
}
