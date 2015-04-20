using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour {

	public GameObject mouseGB;
	public float speed = 0f;
	float x = 5, z = 5;
	Animator animator;
	public bool isKeyDown = false;


	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			isKeyDown = true;
		}else {
			isKeyDown = false;
		}
		x = Input.GetAxis("Horizontal") *speed *Time.deltaTime;
		z = Input.GetAxis("Vertical") *speed *Time.deltaTime;
		animator.SetBool ("keyw", isKeyDown);
		mouseGB.transform.Translate(x, 0, z);

	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Cheese") {
			Destroy(other.gameObject);
			MouseRotation.setCoolDown(.2f);
		}
	}

}
