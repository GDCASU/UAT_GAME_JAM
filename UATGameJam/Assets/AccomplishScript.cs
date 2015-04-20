using UnityEngine;
using System.Collections;

public class AccomplishScript : MonoBehaviour {

	public AudioClip rank1noise;
	public bool spokenAlready1 = false;
	public AudioClip rank7noise;
	public bool spokenAlready7 = false;
	public AudioClip rank6noise;
	public bool spokenAlready6 = false;
	public AudioClip rank5noise;
	public bool spokenAlready5 = false;
	public AudioClip rank4noise;
	public bool spokenAlready4 = false;
	public AudioClip rank3noise;
	public bool spokenAlready3 = false;
	public AudioClip rank2noise;
	public bool spokenAlready2 = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.Find("ScoreController").GetComponent<ScoreScript>().score == 10 && spokenAlready7 == false) 
		{
			AudioSource.PlayClipAtPoint(rank7noise,transform.position);
			spokenAlready7 = true;
		}
		else if (GameObject.Find("ScoreController").GetComponent<ScoreScript>().score == 20 && spokenAlready6 == false) 
		{
			AudioSource.PlayClipAtPoint(rank6noise,transform.position);
			spokenAlready6 = true;
		}
		else if (GameObject.Find("ScoreController").GetComponent<ScoreScript>().score == 30 && spokenAlready5 == false) 
		{
			AudioSource.PlayClipAtPoint(rank5noise,transform.position);
			spokenAlready5 = true;
		}
		else if (GameObject.Find("ScoreController").GetComponent<ScoreScript>().score == 40 && spokenAlready4 == false) 
		{
			AudioSource.PlayClipAtPoint(rank1noise,transform.position);
			spokenAlready4 = true;
		}
		else if (GameObject.Find("ScoreController").GetComponent<ScoreScript>().score == 50 && spokenAlready3 == false) 
		{
			AudioSource.PlayClipAtPoint(rank3noise,transform.position);
			spokenAlready3 = true;
		}
		else if (GameObject.Find("ScoreController").GetComponent<ScoreScript>().score == 60 && spokenAlready2 == false) 
		{
			AudioSource.PlayClipAtPoint(rank3noise,transform.position);
			spokenAlready2 = true;
		}
		else if (GameObject.Find("ScoreController").GetComponent<ScoreScript>().score == 70 && spokenAlready1 == false) 
		{
			AudioSource.PlayClipAtPoint(rank1noise,transform.position);
			spokenAlready1 = true;
		}

	}
}
