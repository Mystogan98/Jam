using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapinScript : MonoBehaviour {

	public GameObject wagon;
	public float speed, clampValue;

	private int direction = -1;
	private float baseAngle, delta = -1f;

	private bool isLaunched = false;

	// Use this for initialization
	void Start () {
		baseAngle = transform.rotation.eulerAngles.z;
	}
	
	// Update is called once per frame
	void Update () {
		if(!isLaunched)
		{
			if(Input.GetMouseButtonDown(0))
			{
				Vector2 parent = new Vector2(wagon.transform.position.x,wagon.transform.position.y);
				Vector2 child = new Vector2(transform.position.x/* + parent.x*/, transform.position.y/* + parent.y*/);

				RaycastHit2D hit2D = Physics2D.Raycast(child,
												new Vector2(((child.x - parent.x) / 
															(child.y - parent.y)) *
															(child.y + delta),
															child.y + delta));
				Debug.DrawLine(child, new Vector2(((child.x - parent.x) / 
															(child.y - parent.y)) *
															(child.y + delta * 200),
															child.y + delta * 200),Color.black,20);
				Debug.DrawLine(child, hit2D.transform.position ,Color.red ,20);
				isLaunched = true;
			} else {
				Debug.Log(transform.rotation.eulerAngles.z);
				if (transform.rotation.eulerAngles.z > baseAngle+clampValue && transform.rotation.eulerAngles.z < baseAngle+clampValue+20)
					direction = -1;
				else if(transform.rotation.eulerAngles.z < (baseAngle+360)-clampValue && transform.rotation.eulerAngles.z > (baseAngle+360)-clampValue-20)
					direction = 1;
				transform.RotateAround(wagon.transform.position,Vector3.forward,speed * Time.deltaTime * direction);
			}
		}
	}
}



// grapin (corde)
// item + drop
// "cinématique"
// actual buffs
// pas de respawn d'item