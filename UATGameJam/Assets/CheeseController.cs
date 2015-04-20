using UnityEngine;
using System.Collections;

public class CheeseController : MonoBehaviour {
	public GameObject cheese;
	public GameObject one;
	public GameObject two;
	public GameObject three;
	public GameObject four;
	public bool isSpawning = false;

	// Use this for initialization
	void Start () {
	
	}
	IEnumerator SpawnObject(float seconds)
	{
		Debug.Log ("Waiting for " + seconds + " seconds");
		
		yield return new WaitForSeconds(seconds);
		spawnCheese ();
		
		//We've spawned, so now we could start another spawn     
		isSpawning = false;
	}
	// Update is called once per frame
	void Update () {

		float seconds = Time.time % 60;
			
			if (seconds > 0) {
				if(! isSpawning)
				{
					isSpawning = true; 
					StartCoroutine(SpawnObject(12.0f));
				}
				
			} 
	}

	void spawnCheese()
	{
		int decision = Random.Range (1, 5);
		if (decision == 1) 
		{
			Instantiate(cheese, one.transform.position, Quaternion.identity);
		}
		else if (decision == 2) 
		{
			Instantiate(cheese, two.transform.position, Quaternion.identity);
		}
		else if (decision == 3) 
		{
			Instantiate(cheese, three.transform.position, Quaternion.identity);
		}
		else
		{
			Instantiate(cheese, four.transform.position, Quaternion.identity);
		}
	}
}
