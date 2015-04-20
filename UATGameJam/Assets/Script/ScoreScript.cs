using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public int score = 0;
	public GameObject myTextGB;
	Text myText;
	public GameObject rankTextGB;
	Text rankText;

	void Awake(){
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		myText = myTextGB.GetComponent<Text> ();
		rankText = rankTextGB.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		myText.text = "Euthanizations: " + score;
		if (score >= 0 && score <= 9) 
		{
			rankText.text = "Rank 8: Feline Friend";
		}
		else if (score >= 10 && score <= 19) 
		{
			rankText.text = "Rank 7: Veterinarian";
		}
		else if (score >= 20 && score <= 29) 
		{
			rankText.text = "Rank 6: Feline Foe";
		}
		else if (score >= 30 && score <= 39) 
		{
			rankText.text = "Rank 5: Tempurra Chef";
		}
		else if (score >= 40 && score <= 49) 
		{
			rankText.text = "Rank 4: Cat Sushi";
		}
		else if (score >= 50 && score <= 59) 
		{
			rankText.text = "Rank 3: Cat Killer";
		}
		else if (score >= 60 && score <= 69) 
		{
			rankText.text = "Rank 2: Neuterer";
		}
		else
		{
			rankText.text = "Rank 1: Can I Has Murder?";
		}
	}

}
