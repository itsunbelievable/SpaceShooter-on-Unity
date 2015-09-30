using UnityEngine;
using System.Collections;

public class spaceInvader : MonoBehaviour {
	float speed = 7.0f;
	public Sprite[] invaders;
	private int spaceInvaderIndex;
	
	void Awake()
	{
		invaders = Resources.LoadAll<Sprite> ("space_invaders");
		transform.localScale =new Vector2 (0.7f, 0.7f);
	}
	// Use this for initialization
	void Start () 
	{
		spaceInvaderIndex = Random.Range (0, 30);
		gameObject.GetComponent<SpriteRenderer>().sprite = invaders[spaceInvaderIndex];
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position += -transform.up * speed * Time.deltaTime;
		Destroy (gameObject, 3.0f);
	}
	
	void OnTriggerEnter2D(Collider2D obj)
	{
		Destroy(gameObject);
		if(obj.name == "bullet(Clone)" || obj.name == "beam(Clone)")
			AddScore();
	}

	public void AddScore()
	{
		if(spaceInvaderIndex <= 5)
			spaceship.score += 10;
		if (spaceInvaderIndex <= 17 && spaceInvaderIndex >5)
			spaceship.score += 50;
		if(spaceInvaderIndex > 17)
			spaceship.score += 100;
	}
}
