using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wwise_GameStates : MonoBehaviour
{
	[SerializeField] private AK.Wwise.Event Music;
	[Header("Scenes")]
	[SerializeField] private AK.Wwise.State MainMenu;
	[SerializeField] private AK.Wwise.State Beach;
	[SerializeField] private AK.Wwise.State Field_Hill;
	[SerializeField] private AK.Wwise.State Field_Farms;
	


	[Space]
	[Header("CaveReverb")]
	[SerializeField] private AK.Wwise.Event CaveReverbEnable;
	[SerializeField] private AK.Wwise.Event CaveReverbDisable;
	

	[Space]
	[Header("Unload SFX on Scene Load")]
	[SerializeField] private AK.Wwise.Event SceneChange;

	private bool music_enabled = false;
	private bool stop=false;
	


	int scene;
	// Start is called before the first frame update
	void Awake()
	{
		GameObject[] objs = GameObject.FindGameObjectsWithTag("Wwise");

		if (objs.Length > 1)
		{
			Destroy(this.gameObject);
		}

		DontDestroyOnLoad(this.gameObject);
	}

	void Start()
    {
		if (!music_enabled)
		{
			Music.Post(gameObject);
			music_enabled = true;
		}

	// 	Debug.LogWarning("Music Play");
		scene = SceneManager.GetActiveScene().buildIndex;
		// Debug.Log(scene);
		

	}
	private void OnEnable()
	{
		SceneManager.sceneLoaded += OnSceneLoaded;
	}
	// Update is called once per frame
	void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode)
	{
		SceneChange.Post(gameObject);
	//	Debug.Log("test!");
	}

	void Update()
    {
		if (SceneManager.GetSceneByName("MainMenu").isLoaded)
		{
			music_enabled = true;
			MainMenu.SetValue();

			if (Level.PreviousLevel == "Field_Hill" && Wwise_TriggerState.reverb_toggler)
			{ stop = false;
				// Debug.Log("получилось");
			}
			CaveReverbDisableEvent();
			Wwise_TriggerState.reverb_toggler = false;
		}
		if (SceneManager.GetSceneByName("Beach").isLoaded)
		{
			Beach.SetValue();
			
		}

		if (SceneManager.GetSceneByName("Field_Hill").isLoaded)
		{
			Field_Hill.SetValue();
			if (Level.PreviousLevel == "Field_Farms" && !stop)
			{
				// Debug.Log("получилось");
				stop = true;
				CaveReverbEnableEvent();
				Wwise_TriggerState.reverb_toggler = true;
			}
			if (Level.PreviousLevel == "Main_Menu" & !stop)
			{
		//		Debug.Log("вернулись в пещеру");
				stop = true;
			}



		}

		if (SceneManager.GetSceneByName("Field_Farms").isLoaded)
		{
			Field_Farms.SetValue();
			CaveReverbDisableEvent();
			Wwise_TriggerState.reverb_toggler = false;
			stop = false;
		}
				
	

	}

	public void CaveReverbEnableEvent()
	{

		CaveReverbEnable.Post(gameObject);
		Debug.LogError("Пещера");
		//AkSoundEngine.ExecuteActionOnPlayingID(AkActionOnEventType.AkActionOnEventType_Pause, Hills.PlayingId);
		
		// Debug.LogError("Пещера: Коллбек");
	}
	public void CaveReverbDisableEvent()
	{

		CaveReverbDisable.Post(gameObject);
		
		//Debug.LogError("Плато");

	}
		
	

}
