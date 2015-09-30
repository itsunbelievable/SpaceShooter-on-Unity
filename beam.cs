using UnityEngine;
using System.Collections;

public class beam : MonoBehaviour {
	public float delay = 2.0f;
	public static bool isShooting;
	
	void Start () 
	{
		isShooting = true;
	}

	void Update () 
	{
		var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//если нажата стрелка влево и координаты кораблика по х больше края, то кораблик двигается
		if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -5.8f) 
		{
			transform.position += move * spaceship.speed * Time.deltaTime;
		}
		//то же для правой стороны
		if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 5.8f) 
		{
			transform.position += move * spaceship.speed * Time.deltaTime;
		}

		InvokeRepeating("Destroy",delay,0f);

	}

	void Destroy()
	{
		Destroy(gameObject);
		isShooting = false;
		FindObjectOfType<spaceship>().SetAlive();
	}
	
}
