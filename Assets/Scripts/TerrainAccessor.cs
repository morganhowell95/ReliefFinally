using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TerrainAccessor : MonoBehaviour {
	public Text accessUpdate;
	public GameObject fpc;

	// Use this for initialization
	void Start () {
		accessUpdate.text = "";
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
		attemptTravel (hit.collider.tag);
	}
		
	void OnTriggerStay(Collider hit) {
		attemptTravel (hit.tag);
	}

	void OnTriggerExit(Collider hit) {
		accessUpdate.text = "";
	}
		
	void attemptTravel(string accessor) {
		switch (accessor) {
		case "snowyTerrainAccessor":
			if (ReliefStats.HAS_ACCESS_TO_SNOWY_TERRAIN) {
				fpc.transform.position = new Vector3(2310.0f, -23.0f, 221.66f);
			} else {
				int delta = ReliefStats.SNOWY_TERRAIN_MAX_COLLECT - ReliefStats.currentSnowyTerrainProgress;
				accessUpdate.text = System.String.Format(ReliefStats.NO_ACCESS_SNOWY_TERRAIN, delta);
			}
			break;
		case "underwaterTerrainAccessor":
			if (ReliefStats.HAS_ACCESS_TO_UNDERWATER_TERRAIN) {
				//transport FPC to the center of the underwater terrain 
			} else {
				int delta = ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT - ReliefStats.currentUnderwaterTerrainProgress;
				accessUpdate.text = System.String.Format(ReliefStats.NO_ACCESS_UNDERWATER_TERRAIN, delta);
			}
			break;
		}
	}
		
}
