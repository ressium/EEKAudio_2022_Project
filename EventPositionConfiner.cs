////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2018 Audiokinetic Inc. / All Rights Reserved
//
////////////////////////////////////////////////////////////////////////

﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class EventPositionConfiner : MonoBehaviour
{
	[Header("Event to clamp to AkAudioListener")]
	public AK.Wwise.Event Event;

	[Header("Settings")]
	public float UpdateInterval = 0.05f;

	#region private variables
	private IEnumerator positionClamperRoutine;

	private Collider trigger;
	private Transform targetTransform;

	private GameObject eventEmitter;
	private AkAudioListener listenerGameObject;
	
	
	#endregion

	private void Awake()
	{
		
	}

	void Start()
	{
		StartCoroutine(WaitToDisplay(1.0f));
		StopCoroutine("WaitToDisplay");

		// var listenerGameObject = FindObjectOfType<AkAudioListener>();

		//	if (listenerGameObject != null)
		//	{
		//		targetTransform = listenerGameObject.transform;
		//		
		//	}
		//	else
		//	{
		//		Debug.LogError(this + ": No GameObject with 'AkAudioListener' Component found! Aborting.");
		//	enabled = false;
		//	}

	}

	void ActivateEmitter()
	{
		trigger = GetComponent<Collider>();
		trigger.isTrigger = true;

		eventEmitter = new GameObject("Clamped Emitter");
		eventEmitter.transform.parent = transform;
		// eventEmitter.transform.localPosition = new Vector3(0, 0, 0);
		Rigidbody RB = eventEmitter.AddComponent<Rigidbody>();
		RB.isKinematic = true;
		SphereCollider SPC = eventEmitter.AddComponent<SphereCollider>();
		SPC.isTrigger = true;
		eventEmitter.AddComponent<AkGameObj>();
		Event.Post(eventEmitter);

		positionClamperRoutine = ClampEmitterPosition();
		StartCoroutine(positionClamperRoutine);
	}

	

	private void OnDisable()
	{
		Event.Stop(eventEmitter);

		if (positionClamperRoutine != null)
		{
			StopCoroutine(positionClamperRoutine);
		}
	}




	IEnumerator WaitToDisplay(float seconds)
	{
		Debug.LogWarning("ищём");
		yield return new WaitForSeconds(seconds);
		listenerGameObject = FindObjectOfType<AkAudioListener>();
		if (listenerGameObject != null)
		{
			targetTransform = listenerGameObject.transform;
			ActivateEmitter();
			Debug.LogWarning("нашел");
			
		}
		else
		{
			Debug.LogError(this + ": No GameObject with 'AkAudioListener' Component found! Aborting.");
		}

	}
	IEnumerator ClampEmitterPosition()
    {
		while (true)
		{
			Vector3 closestPoint = trigger.ClosestPoint(targetTransform.position);
			eventEmitter.transform.position = closestPoint;
			Debug.LogWarning("позиция: " + targetTransform.position);
			Debug.LogWarning("Эмиттер: " + eventEmitter.transform.position);
			yield return new WaitForSecondsRealtime(UpdateInterval);
			if (targetTransform = null)
			{
				Debug.LogWarning("Свинка Пропала");
				listenerGameObject = FindObjectOfType<AkAudioListener>();
				if (listenerGameObject != null)
				{
					targetTransform = listenerGameObject.transform;
					Debug.LogWarning("Свинка Нашлась");
				}
			}
			
		}
	}

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        if (eventEmitter != null)
        {
            Gizmos.DrawSphere(eventEmitter.transform.position, 0.2f);
        }
    }

}
