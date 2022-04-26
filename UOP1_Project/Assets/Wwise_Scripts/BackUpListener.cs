using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackUpListener : MonoBehaviour
{
	private CharacterController AKListener;

	// Start is called before the first frame update
	void Start()
    {
		AKListener = FindObjectOfType<CharacterController>();

		if (AKListener != null)
		{ Destroy(this); }
	}

    // Update is called once per frame
    void Update()
    {
		AKListener = FindObjectOfType<CharacterController>();

		if (AKListener != null)
		{ Destroy(this); }
    }
}
