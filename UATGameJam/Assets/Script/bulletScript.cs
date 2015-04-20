using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

	public Rigidbody bullet;
	float speed = 40f;
	float startTime = 0;
	float duration = 1f;
	public AudioClip catsound1;
	public AudioClip catsound2;
	public AudioClip catsound3;
	public AudioClip catsound4;
	public AudioClip catsound5;

	GameObject wallGb;
	// Use this for initialization
	void Start () {
		bullet.velocity = bullet.velocity * speed;
		startTime = 0;
	}
	// Update is called once per frame
	void Update () {
		startTime += Time.deltaTime;
		if (startTime >= duration) {
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Wall") {
			Debug.Log ("WALL DELETE");
			Destroy(this.gameObject);
		}
		if (other.gameObject.tag == "Cat") {
			Debug.Log ("CAT DELETE");
			GameObject.Find("ScoreController").GetComponent<ScoreScript>().score++;
			other.gameObject.transform.Find("Cat-Asset").gameObject.SetActive(false);
			other.gameObject.transform.Find("CatDead").gameObject.SetActive(true);
			other.gameObject.GetComponent<EricFollowScript>().isDeath = true;
			Destroy(this.gameObject);
			int decision = Random.Range (1, 6);
			if (decision == 1) 
			{
				AudioSource.PlayClipAtPoint(catsound1, transform.position);
			}
			else if (decision == 2) 
			{
				AudioSource.PlayClipAtPoint(catsound2, transform.position);
			}
			else if (decision == 3) 
			{
				AudioSource.PlayClipAtPoint(catsound3, transform.position);
			}
			else if (decision == 4) 
			{
				AudioSource.PlayClipAtPoint(catsound4, transform.position);
			}
			else
			{
				AudioSource.PlayClipAtPoint(catsound5, transform.position);
			}
		}
		if (other.gameObject.tag == "PlayScreen") {
			Application.LoadLevel ("Game");
		}
		if (other.gameObject.tag == "QuitScreen") {
			Application.Quit();
		}
		if (other.gameObject.tag == "MenuScreen") {
			Application.LoadLevel ("Menu");
		}
	}
}
