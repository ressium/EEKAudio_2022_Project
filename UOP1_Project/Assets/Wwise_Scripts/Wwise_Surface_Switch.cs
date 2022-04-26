using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wwise_Surface_Switch : MonoBehaviour
{
	[SerializeField] private GameObject Player;
	[SerializeField] private LayerMask lm;

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 0.03f, lm)) // запускаем рейкаст из объекта нужной ноги вниз
		{
			AkSoundEngine.SetSwitch("Footsteps", hit.collider.tag, Player); // выставляем свитч нужной свитч-группы в положение такое же как тэг поверхности, на которую наступила нога, применяем свитч для нужной ноги
		//	Debug.LogError(hit.collider.tag);
		}
		Debug.DrawRay(gameObject.transform.position, -gameObject.transform.up * 1f, Color.red, 0.03f);
	}
	

}

