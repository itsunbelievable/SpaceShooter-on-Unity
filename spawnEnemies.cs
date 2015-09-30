using UnityEngine;
using System.Collections;

public class spawnEnemies : MonoBehaviour {
	public GameObject spinv;
	public GameObject bonus;
	public float spawn = 0.8f;
	private Manager manager;

	IEnumerator Start () 
	{
			manager = FindObjectOfType<Manager> ();
			while (manager.IsPlaying() == false) {
				yield return new WaitForEndOfFrame();
			}
			InvokeRepeating ("AddEnemy", spawn, 0.3f);
	}

	void Update () 
	{

	}

	void AddEnemy()
	{  
		var spawnPoint = new Vector2 (Random.Range (-5, 5), transform.position.y);
		if (manager.IsPlaying ()) 
		{
			Instantiate (spinv, spawnPoint, Quaternion.identity);
			if(Random.Range(1,30) == 1){
				Instantiate(bonus, new Vector2 (Random.Range (-5, 5), transform.position.y), Quaternion.identity);
            }
		}
	}
}
