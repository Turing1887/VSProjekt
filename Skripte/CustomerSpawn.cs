using UnityEngine;
using System.Collections;

public class CustomerSpawn : MonoBehaviour {


	public GameObject customer;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawn",Random.Range(4f,10f),Random.Range(4f,10f));
	}


	void Spawn(){
		Vector3 spawnPoint = transform.position;
		Instantiate (customer,spawnPoint,Quaternion.identity);

	}	
}
