using UnityEngine;
using System.Collections;

public class bonus : MonoBehaviour {
	public float speed = 7.0f; 


	void Start () 
	{
		transform.localScale = new Vector2(0.4f,0.4f);
	}
	

	void Update () 
	{
		transform.position+= -transform.up * speed * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D obj){
		if(obj.name == "spaceship(Clone)")
		{
			Destroy(gameObject);
		}
	}
}
