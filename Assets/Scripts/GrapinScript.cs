using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GrapinScript : MonoBehaviour {

	public GameObject wagon;
	public float speed, clampValue, speedVertical;
	public Sprite Closed;
	public SpriteRenderer Black;
	public PlayerBuffScript playerBuff;

	private int direction = 1;
	private float baseAngle, delta = -1f, baseY, alpha = 0.001f;

	private bool isLaunched = false;
	private RaycastHit2D target;
	private SpriteRenderer spr;

	// Use this for initialization
	void Start () {
		baseAngle = transform.rotation.eulerAngles.z;
		baseY = transform.position.y;
		spr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < 0)
		{
			transform.parent.position += Vector3.right * 3 * Time.deltaTime;
			return;
		}
		if(direction != 0)
		{
			if(!isLaunched)
			{
				if(Input.GetMouseButtonDown(0) || Input.GetAxisRaw("Vertical") == -1)
				{
					Vector2 parent = new Vector2(wagon.transform.position.x,wagon.transform.position.y);
					Vector2 child = new Vector2(transform.position.x/* + parent.x*/, transform.position.y/* + parent.y*/);

					target = Physics2D.Raycast(child,
													new Vector2(((child.x - parent.x) / 
																(child.y - parent.y)) *
																(child.y + delta * 20),
																child.y + delta * 20));
					Debug.DrawLine(child, new Vector2(((child.x - parent.x) / 
																(child.y - parent.y)) *
																(child.y + delta * 200),
																child.y + delta * 200),Color.black,20);
					Debug.DrawLine(child, target.transform.position ,Color.red ,20);
					direction = -1;
					isLaunched = true;
				} else {
					if (transform.rotation.eulerAngles.z > baseAngle+clampValue && transform.rotation.eulerAngles.z < baseAngle+clampValue+20)
						direction = -1;
					else if(transform.rotation.eulerAngles.z < (baseAngle+360)-clampValue && transform.rotation.eulerAngles.z > (baseAngle+360)-clampValue-20)
						direction = 1;
					transform.RotateAround(wagon.transform.position,Vector3.forward,speed * Time.deltaTime * direction);
				}
			} else {
				transform.Translate(new Vector3(0,direction * speedVertical * Time.deltaTime, 0),transform);
				if (direction == 1)
				{
					target.transform.Translate(new Vector3(0,direction * speedVertical * Time.deltaTime, 0),transform);
				}
				if (transform.position.y >= baseY && spr.sprite == Closed)
					direction = 0;
				else if (transform.position.y <= target.transform.position.y)
				{
					spr.sprite = Closed;
					direction = 1;
				}
			}
		} else {
			transform.parent.position += Vector3.right * 3 * Time.deltaTime;
			target.transform.position += Vector3.right * 3 * Time.deltaTime;
			if(transform.position.x >= 8)
			{
				alpha *= 1.1f;
				Black.color = new Color(1,1,1,alpha);
			}
			if(alpha >= 0.9 && alpha < 1.1)
			{
				alpha = 2;
				TriggerScript trg =	target.collider.gameObject.GetComponent<TriggerScript>();
				if(trg != null)
					trg.action.Invoke();

				Debug.Log("1");
				SceneManager.LoadScene("Level",LoadSceneMode.Single);
				// Debug.Log("2");
				// //SceneManager.MoveGameObjectToScene(playerBuff.gameObject,SceneManager.GetSceneByName("Level"));
				// Debug.Log("3");
				// SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Shop"));
				// Debug.Log("4");
			}
		}
	}
}



// corde
// item + drop
// "cinématique"
// actual buffs
// pas de respawn d'item