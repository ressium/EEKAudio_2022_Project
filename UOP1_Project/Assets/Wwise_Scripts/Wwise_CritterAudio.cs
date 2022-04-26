using UnityEngine;

public class Wwise_CritterAudio : CharacterAudio
{
	[SerializeField] private AK.Wwise.Event idleSound, moveSound, attackSound, gettingHitSound, deathSound;
	[SerializeField] private GameObject _critter;

	public void PlayIdleSound() => PlayAudioWwise(idleSound, _critter);
	//The move sound will not be called for the plant critter
	public void PlayMoveSound() => PlayAudioWwise(moveSound, _critter);
	public void PlayAttackSound() => PlayAudioWwise(attackSound, _critter);
	public void PlayGettingHitSound() => PlayAudioWwise(gettingHitSound, _critter);
	public void PlayDeathSound() => PlayAudioWwise(deathSound, _critter);

}
