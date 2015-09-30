using UnityEngine;

public class Manager : MonoBehaviour {

	public GameObject spaceship;

	private GameObject title;
	// Use this for initialization

	void Awake()
	{
		title = GameObject.Find("TitleScreen");
	}
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X)) 
		{
			GameStart();
		}
	}

	void GameStart()
	{
		title.SetActive (false);
		Instantiate (spaceship, spaceship.transform.position, Quaternion.identity);
		for (int i = 1; i<4;i++)
		GameObject.Find(i.ToString()).GetComponent<SpriteRenderer>().color = Color.green;
	}

	public void GameOver()
	{
		title.SetActive (true);
	}

	public bool IsPlaying()
	{
		return title.activeSelf == false;
	}

}
