using UnityEngine;
using System.Collections;

public class WalkToward : MonoBehaviour {

	private RaycastHit hit;
	private CardboardHead head;
	public float speed = 0.2f;
	public CharacterController controller;
	private float delay = 0.0f;
	public GameObject cardboardMain;
	// Use this for initialization
	void Start () {
		head = Camera.main.GetComponent<StereoController> ().Head;
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (head.Gaze, out hit, Mathf.Infinity)) {
			if (hit.collider.tag == "Object") {
				hit.transform.SendMessage ("HitByRay");

				Vector3 tarPos = hit.transform.position;
				InvokeRepeating ("MovementDelay", 1, 1);
				if (delay == 2.0f) {
					CancelInvoke ();
					MoveTowards (tarPos);	
				}	

			} 
		}
		else {
			delay = 0.0f;
		}

	}

	void MoveTowards(Vector3 target){
		Vector3 offset = target - cardboardMain.transform.position;

		if(offset.magnitude > 1.0f){
			offset = offset.normalized * speed;
			controller.Move (offset * Time.deltaTime);
		}
	}

	void MovementDelay(){
		delay += 1.0f;

	}
		
}
