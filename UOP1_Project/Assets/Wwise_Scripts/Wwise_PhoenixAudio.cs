using UnityEngine;

public class Wwise_PhoenixAudio : CharacterAudio
{
	[SerializeField] private AK.Wwise.Event nibble, sneezing, flap;
	[SerializeField] private GameObject _npc;

	//when we have the ground detector script, we should check the type to know which footstep sound to play
	public void PlayFlap() => PlayAudioWwise(flap, _npc);
	public void PlaySneezing() => PlayAudioWwise(sneezing, _npc);
	
	public void PlayNibble() => PlayAudioWwise(nibble, _npc);
	

}
