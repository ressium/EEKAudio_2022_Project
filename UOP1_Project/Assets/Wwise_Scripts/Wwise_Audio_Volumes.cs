using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_Audio_Volumes : MonoBehaviour
{
	[SerializeField] private SettingsSO _currentSettings = default;
	[SerializeField] private AK.Wwise.RTPC MasterVolume;
	[SerializeField] private AK.Wwise.RTPC MusicVolume;
	[SerializeField] private AK.Wwise.RTPC SfxVolume;
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		MasterVolume.SetGlobalValue(_currentSettings.MasterVolume);
		MusicVolume.SetGlobalValue(_currentSettings.MusicVolume);
		SfxVolume.SetGlobalValue(_currentSettings.SfxVolume);


	//	Debug.Log("Общая Громкость: " + _currentSettings.MasterVolume);
	//	Debug.Log("Музыка Громкость: " + _currentSettings.MusicVolume);
	//	Debug.Log("Эффекты Громкость: " + _currentSettings.SfxVolume);

	}
}
