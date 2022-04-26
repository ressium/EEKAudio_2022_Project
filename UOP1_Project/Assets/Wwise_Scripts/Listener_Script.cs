using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Listener_Script : MonoBehaviour
{

    
    public GameObject Camera;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
		Camera = GameObject.FindGameObjectWithTag("MainCamera");
		Player = GameObject.FindGameObjectWithTag("Player");

	}

	// Update is called once per frame

	void Update()
	{
		if (Player != null & Camera != null)
		{
			transform.position = (Camera.transform.position + Player.transform.position) / 2;
		}
		else
		{
			Player = GameObject.FindGameObjectWithTag("Player");
			Camera = GameObject.FindGameObjectWithTag("MainCamera");
		}
	}
}
