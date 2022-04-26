using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AK.Wwise;


public class Wwise_UI_Sounds : MonoBehaviour
{
	[SerializeField] private AK.Wwise.Event UIClick;
	[SerializeField] private AK.Wwise.Event UIShuffle;
	[SerializeField] private AK.Wwise.Event UISelect;
	[SerializeField] private AK.Wwise.Event UIUse;

	// Start is called before the first frame update
	public void UIClickSound()
	{
		// AkSoundEngine.PostEvent(sound_event,gameObject);
		UIClick.Post(gameObject);
	}

	public void UIShuffleSound()
	{
		// AkSoundEngine.PostEvent(sound_event,gameObject);
		UIShuffle.Post(gameObject);
	}

	public void UISelectSound()
	{
		// AkSoundEngine.PostEvent(sound_event,gameObject);
		UISelect.Post(gameObject);

	}
	public void UIUseSound()
	{
		// AkSoundEngine.PostEvent(sound_event,gameObject);
		UIUse.Post(gameObject);

	}
}
