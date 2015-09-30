using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class backScript : MonoBehaviour {

	public float speed = 0.5f;
	public Text pause;
	public Text Score;
	public static bool isPaused;
	
	// Use this for initialization
	void Start () 
	{
		Pause (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector2 offset = new Vector2 (0, Time.time * speed);
		GetComponent<Renderer>().material.mainTextureOffset = offset;

		if (Input.GetKeyDown (KeyCode.P))
		{
			isPaused = !isPaused;
			Pause(isPaused);
			if(isPaused)
				pause.text = "PAUSE";
			else
				pause.text = null;
		}

		Score.text = spaceship.score.ToString();
	}

	void Pause(bool isPaused)
	{
		if(isPaused)
		{
			Time.timeScale = 0;
			gameObject.GetComponent<AudioSource>().mute = true;
		}
		if(!isPaused)
		{
			Time.timeScale = 1;
			gameObject.GetComponent<AudioSource>().mute = false;
		}
	}
}
