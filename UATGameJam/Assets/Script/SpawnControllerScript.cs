using UnityEngine;
using System.Collections;

public class SpawnControllerScript : MonoBehaviour {

	public GameObject cat;
	public GameObject north;
	public GameObject south;
	public GameObject left;
	public GameObject right;
	public bool isSpawning = false;
	public bool CatMed = false;
	public bool CatHard = false;
	
	
	// Use this for initialization
	void Start () {
		
	}
	IEnumerator SpawnObject(float seconds)
	{
		Debug.Log ("Waiting for " + seconds + " seconds");
		
		yield return new WaitForSeconds(seconds);
		spawnCat ();
		
		//We've spawned, so now we could start another spawn     
		isSpawning = false;
	}
	// Update is called once per frame
	void Update () {
		float seconds = Time.time % 60;
		
		if (seconds < 15) {
			if(! isSpawning)
			{
				isSpawning = true; 
				StartCoroutine(SpawnObject(3.0f));
			}
			
		} 
		else if (seconds > 15 && seconds < 30) 
		{
			if(! isSpawning)
			{
				isSpawning = true; 
				StartCoroutine(SpawnObject(2.0f));
			}
			
		} 
		else if (seconds > 30 && seconds < 60) 
		{
			EricFollowScript.moveSpeed = 9.0f;
			if(! isSpawning)
			{
				isSpawning = true; 
				StartCoroutine(SpawnObject(1.0f));
			}
		}
		else if (seconds > 60) 
		{
			EricFollowScript.moveSpeed = 12.0f;
			if(! isSpawning)
			{
				isSpawning = true; 
				StartCoroutine(SpawnObject(1.0f));
			}
		}
		
	}
	
	void spawnCat()
	{
		int decision = Random.Range (1, 5);
		if (decision == 1) 
		{
				Instantiate(cat, north.transform.position, Quaternion.identity);


		}
		else if (decision == 2) 
		{
			Instantiate(cat, left.transform.position, Quaternion.identity);
		}
		else if (decision == 3) 
		{
			Instantiate(cat, right.transform.position, Quaternion.identity);
		}
		else
		{
			Instantiate(cat, south.transform.position, Quaternion.identity);
		}
	}
	
	
}
