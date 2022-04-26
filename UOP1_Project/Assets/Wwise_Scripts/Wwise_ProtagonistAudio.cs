using UnityEngine;

public class Wwise_ProtagonistAudio : CharacterAudio
{
	/*
	[SerializeField] private AudioCueSO _caneSwing;
	[SerializeField] private AudioCueSO _liftoff;
	[SerializeField] private AudioCueSO _land;
	[SerializeField] private AudioCueSO _objectPickup;
	[SerializeField] private AudioCueSO _footsteps;
	[SerializeField] private AudioCueSO _getHit;
	[SerializeField] private AudioCueSO _die;
	[SerializeField] private AudioCueSO _talk;
	*/
	[SerializeField] private AK.Wwise.Event _caneSwing, _liftoff, _land, _objectPickup, _footsteps, _getHit, _die, _talk;
	[SerializeField] private GameObject _player;


	//public void PlayFootstep() => PlayAudioWwise(_footsteps, _player);
	public void PlayJumpLiftoff() => PlayAudioWwise(_liftoff, _player);
	public void PlayJumpLand() => PlayAudioWwise(_land, _player);
	public void PlayCaneSwing() => PlayAudioWwise(_caneSwing, _player);
	public void PlayObjectPickup() => PlayAudioWwise(_objectPickup, _player);
	public void PlayGetHit() => PlayAudioWwise(_getHit, _player);
	public void PlayDie() => PlayAudioWwise(_die, _player);
	public void PlayTalk() => PlayAudioWwise(_talk, _player);

	public void PlayFootstep(string log)
	{
		_footsteps.Post(_player);
	//	Debug.LogError("Foot: " + log);
	}
}
