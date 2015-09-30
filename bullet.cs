using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class bullet : MonoBehaviour {
	float speed = 10.0f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += transform.up*speed * Time.deltaTime;
		Destroy(gameObject, 3);
	}

	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.name == "spaceInvader(Clone)")
		{
			Destroy(gameObject);
		}
	}


}