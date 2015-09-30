using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class spaceship : MonoBehaviour {
	public static float speed = 10.0f;
	int lives = 3;
	public GameObject bull;
	public GameObject ship;
	public GameObject explosion;
	public GameObject beam;
	public static int score;
	Manager manager;
	private int blinkCount;

	//флаг для респа кораблика
	private bool invincible = false;
	// Use this for initialization
	void Start () 
	{
		score = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//вектор движения корабля по горизонтали
		var move = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
		//если нажата стрелка влево и координаты кораблика по х больше края, то кораблик двигается
		if (Input.GetKey(KeyCode.LeftArrow) && transform.position.x >= -5.8f) 
		{
			transform.position += move * speed * Time.deltaTime;
		}
		//то же для правой стороны
		if (Input.GetKey(KeyCode.RightArrow) && transform.position.x <= 5.8f) 
		{
			transform.position += move * speed * Time.deltaTime;
		}

	// на пробел инстанцируем новую пульку
		if (Input.GetKeyDown(KeyCode.Space) && !backScript.isPaused && !GameObject.Find("beam (Clone)")) 
		{
			Instantiate(bull,transform.position, Quaternion.identity);
		}
	}

	void OnTriggerEnter2D(Collider2D obj)
	{
		//проверяем, с каким объектом столкнулся кораблик
		if (obj.name == "spaceInvader(Clone)")
		{
		// если это не первые три секунды после респауна,
			//то уменшаем количество жизней и инстанцируем взрыв
		  if(!invincible)
		  {
			gameObject.GetComponent<SpriteRenderer>().enabled = false;
			gameObject.SetActive(false); 
			Instantiate(explosion, transform.position, Quaternion.identity);
			GameObject.Find(lives.ToString()).GetComponent<SpriteRenderer>().color = Color.red;
			lives--;
			if(lives > 0)
			{
				Invoke("InstantiateAfterTime", 1.0f);
				Invoke("SetAlive",3.0f);
			}
			else
			{
				Destroy(gameObject);
				FindObjectOfType<Manager>().GameOver();
			}
		  }
		}
		if (obj.name == "bonus(Clone)")
		{
			invincible = true;
			Instantiate(beam,new Vector3(transform.position.x ,1f,0f), Quaternion.identity);
		}


	}

	IEnumerator InstantiateAfterTime()
	{
		gameObject.GetComponent<SpriteRenderer>().enabled = true;
		gameObject.SetActive (true);
		invincible = true;
		while(blinkCount < 5)
		{
			gameObject.GetComponent<Renderer>().enabled = !gameObject.GetComponent<Renderer>().enabled;
			if(gameObject.GetComponent<Renderer>().enabled)
				blinkCount++;
			yield return new WaitForSeconds(.1f);
		}
		blinkCount = 0;
	}

	public void SetAlive()
	{
		invincible = false;
	}


	
}
