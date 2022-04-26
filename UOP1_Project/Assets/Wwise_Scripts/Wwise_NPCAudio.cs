using UnityEngine;

public class Wwise_NPCAudio : CharacterAudio
{
	[SerializeField] private AK.Wwise.Event Sing, talk, footstep;  //singShort - commited
	[SerializeField] private GameObject _npc;

	//when we have the ground detector script, we should check the type to know which footstep sound to play
	public void PlayFootstep() => PlayAudioWwise(footstep, _npc);
	public void PlayTalk() => PlayAudioWwise(talk, _npc);
	//Only bard hare will use the Idle since he sings at that time
//	public void PlaySingShort() => PlayAudioWwise(singShort, _npc);
	public void PlaySing() => PlayAudioWwise(Sing, _npc);

}
