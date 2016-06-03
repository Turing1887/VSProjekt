using UnityEngine;
using System.Collections;

public class Glow : MonoBehaviour {

	Material mat;
	Color currCol;
	Color newCol;
	Renderer rend;
	// Use this for initialization
	void Awake () {
		rend = GetComponent<Renderer> ();
		mat = rend.material;

	}

	void FixedUpdate(){
		NotHit ();
	}

	void HitByRay(){
		
		mat.EnableKeyword ("_EMISSION");

	}

	void NotHit(){
		mat.DisableKeyword ("_EMISSION");
	}



}
