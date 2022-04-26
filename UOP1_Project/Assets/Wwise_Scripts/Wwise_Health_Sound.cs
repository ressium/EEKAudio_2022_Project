using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_Health_Sound : MonoBehaviour
{
	[SerializeField] private HealthSO _health;
	[SerializeField] private AK.Wwise.RTPC healthParam;
	[SerializeField] private AK.Wwise.Event HeartBeat;
	// Start is called before the first frame update
	void Start()
    {
        
    }

	private void OnEnable()
	{
		HeartBeat.Post(gameObject);
	}

	private void OnDisable()
	{
		HeartBeat.Stop(gameObject, 50, AkCurveInterpolation.AkCurveInterpolation_Log3);	
	}
	// Update is called once per frame
	void Update()
    {
		healthParam.SetValue(gameObject, _health.CurrentHealth);
	//	Debug.LogWarning("Çהמנמגüו: " + _health.CurrentHealth);
    }


}
