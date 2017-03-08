using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupShape : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			PickupItem();
		}
	}


	void PickupItem() {
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 10)){
			if (hit.collider.tag == "chest") {
				Destroy (hit.collider.gameObject);
			}
		}
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		print ("test");
		if(hit.collider.tag == "chest")
		{
			Destroy(hit.collider.gameObject);
		}
	}
}
