using UnityEngine;
using System.Collections;

public class EricFollowScript : MonoBehaviour {

	GameObject playerGB;
	public static float moveSpeed = 18f;
	public bool isDeath = false;
	public float deathTime = 0f;
	// Use this for initialization
	void Start () {
		playerGB = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (moveSpeed); 
		if (!isDeath) {
			this.transform.position = Vector3.MoveTowards (this.transform.position, playerGB.transform.position, moveSpeed * Time.deltaTime);
			this.transform.LookAt (playerGB.transform);
			float dist = Vector3.Distance (this.transform.position, playerGB.transform.position);
			if (dist < 13f) {
				Application.LoadLevel ("Ending");
			}
		}
		if (isDeath) {
			//moveSpeed = 0f;
			deathTime += Time.deltaTime;
		}
		if (deathTime >= .5f) {

			Destroy(gameObject);
		}
	}

	static void incMoveSpd(float increase)
	{
		moveSpeed = increase;
	}	
}
