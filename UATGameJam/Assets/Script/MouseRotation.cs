using UnityEngine;
using System.Collections;

public class MouseRotation : MonoBehaviour {

	public static float cooldownTimer;
	float cooltime;
	public GameObject bullet;
	public GameObject muzzle;
	public float speed;
	public AudioClip gunnoise;
	public static bool timing = false;
	public static float countdown = 0;

	//projectile
	Vector3 targetPoint;

	// Use this for initialization
	void Start () {
		targetPoint = Vector3.zero;
		speed = 20f;
		cooltime = 1f;
		cooldownTimer = .60f;
	}

	void FixedUpdate(){
		// Generate a plane that intersects the transform's position with an upwards normal.
		Plane playerPlane = new Plane(Vector3.up, transform.position);
		
		// Generate a ray from the cursor position
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		float hitdist = 0.0f;
		// If the ray is parallel to the plane, Raycast will return false.
		if (playerPlane.Raycast (ray, out hitdist)) 
		{
			// Get the point along the ray that hits the calculated distance.
			targetPoint = ray.GetPoint(hitdist);
			
			// Determine the target rotation.  This is the rotation if the transform looks at the target point.
			Quaternion targetRotation = Quaternion.LookRotation(targetPoint - transform.position);
			
			// Smoothly rotate towards the target point.
			transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
		}
	}
	
	// Update is called once per frame
	void Update () {


		if (Input.GetMouseButton (0)) {
			if(cooltime >= cooldownTimer){
				Debug.Log ("FIRE");
				fire ();
				AudioSource.PlayClipAtPoint (gunnoise,transform.position);
			}
		}
		cooltime += Time.deltaTime;
		if (timing) 
		{
			countdown -= Time.deltaTime;
			if(countdown <= 0)
			{
				cooldownTimer = 0.6f;
				timing = false;
			}
		}
	}

	public static void setCoolDown(float decrease){
		cooldownTimer -= decrease;
		StartTimer (6.0f);
	}
	static void StartTimer(float time)
	{
		timing = true;
		countdown = time;
	}
	void fire(){
		cooltime = 0f;
		GameObject bullet_clone;

		bullet_clone = Instantiate(bullet, muzzle.transform.position, muzzle.transform.rotation) as GameObject;
		bullet_clone.transform.parent = this.gameObject.transform;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		float hitdist = 0.0f;
		Vector3 dir = Vector3.Normalize (ray.GetPoint(hitdist) - this.transform.position);
		dir = new Vector3 (dir.x, 0, dir.z);
		bullet_clone.GetComponent<Rigidbody>().velocity = this.gameObject.transform.forward+( dir* 4); 
		bullet_clone.transform.parent = null;
	}

}
