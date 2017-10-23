using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_flover : MonoBehaviour {
	public Transform flover1;

	// Use this for initialization
	void Start () {
		for (var y = 0; y < 5; y++) {
			for (var x = 0; x < 5; x++) {
				Instantiate (flover1, new Vector3 (x, y, 0), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
