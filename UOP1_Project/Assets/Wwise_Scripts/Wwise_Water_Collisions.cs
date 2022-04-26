using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Wwise_Water_Collisions : MonoBehaviour
{
	[SerializeField] private GameObject Character;
	

	private Vector3 lastUpdatePos = Vector3.zero;
	private Vector3 dist;
	private float currentSpeed;

	[SerializeField] private AK.Wwise.State Underwater_On;
	[SerializeField] private AK.Wwise.State Underwater_Off;
	[SerializeField] private AK.Wwise.Event WaterSpash;
	[SerializeField] float footstepSpeed = 0.3f;
	float timer = 0.0f;
	bool isMoving;

	[SerializeField] private Collider Water;
	[SerializeField] private Collider Player;
	float percentage;

	// Start is called before the first frame update
	void Start()
    {
		Underwater_Off.SetValue();
		Player = Character.GetComponent<Collider>();



	}
	bool IsGrounded()
	{
		RaycastHit hit;

		if (Physics.Raycast(Character.transform.position, -Character.transform.up, out hit, 1f))
		{
	//		Debug.LogWarning("на земле");
			return true;
		}
		else
		{
	//		Debug.LogWarning("в воздухе");
			return false;
		}
	}

	private void Update()
	{
		


		if (SceneManager.GetSceneByName("Beach").isLoaded)
		{ var water_obj = GameObject.Find("WaterPlane");
			Water = water_obj.GetComponent<Collider>();


			isMoving = IsGrounded() && currentSpeed > 1f;
	//		Debug.Log("%: " + BoundsContainedPercentage(Player.bounds, Water.bounds));
		//	Debug.Log("Положение " + Player.transform.position.y);


			dist = Character.transform.position - lastUpdatePos;
			currentSpeed = dist.magnitude / Time.deltaTime;
			lastUpdatePos = Character.transform.position;
	//		Debug.LogWarning(gameObject.name + " movement speed is:" + currentSpeed);

			IsGrounded();
		//	Debug.DrawRay(Character.transform.position, -Character.transform.up * 1f, Color.red, 1f);
		}

		if (Water != null)		{ WaterSteps(); }

		

	}

	void WaterSteps() { 

		percentage = BoundsContainedPercentage(Player.bounds, Water.bounds);

		if ((percentage > 0.4f || Player.transform.position.y < -11f) && isMoving)
		{
			if (timer > footstepSpeed)
			{
				WaterSpash.Post(gameObject);
				timer = 0.0f;
		//		Debug.LogError("фыр-фыр");
			}

			timer += Time.deltaTime;
		}

		if (Player.transform.position.y < -11f)
		{
			Underwater_On.SetValue();
		//	Debug.Log("утонул");
		}
		else
		{
			Underwater_Off.SetValue();
		//	Debug.Log("дышим");
		}

	


			
		}

	

	private float BoundsContainedPercentage(Bounds obj, Bounds region)
	{
		var total = 1f;

		for (var i = 0; i < 3; i++)
		{
			var dist = obj.min[i] > region.center[i] ?
				obj.max[i] - region.max[i] :
				region.min[i] - obj.min[i];

			total *= Mathf.Clamp01(1f - dist / obj.size[i]);
		}

		return total;
	}
}
