using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupShape : MonoBehaviour {
	
	public Text piecePickupProgress;

	void Start () {
		piecePickupProgress.text = "";
		ReliefStats.Instance.currentSnowyTerrainProgress = 0;
	}

	void showPiecePickupProgress(string pieceType, GameObject piece) {
		switch (pieceType) {

		case "snowPiece":
			piece.SetActive (false);
			updateProgressWinterCoat (parseID (piece.name));
			break;

		case "underwaterPiece":
			piece.SetActive (false);
			updateProgressScubaGear (parseID (piece.name));
			break;
		}

		//Invoke ("eraseCurrentStatus", 10); //delays erase for three seconds
	}
		
	void eraseCurrentStatus() {
		piecePickupProgress.text = "";
	}
		
	void updateProgressWinterCoat(int id){
		if (id <= ReliefStats.SNOWY_TERRAIN_MAX_COLLECT) {
			Debug.Log (ReliefStats.Instance.currentSnowyTerrainProgress);
			ReliefStats.Instance.snowyTerrainPiecesFound [id] = true;
		}
		ReliefStats.Instance.currentSnowyTerrainProgress++;

		if (ReliefStats.Instance.currentSnowyTerrainProgress < ReliefStats.SNOWY_TERRAIN_MAX_COLLECT) {
			piecePickupProgress.text = System.String.Format(ReliefStats.Instance.SNOWY_TERRAIN_PIECE_RETRIEVED, ReliefStats.Instance.currentSnowyTerrainProgress);
		} else {
			piecePickupProgress.text = ReliefStats.Instance.SNOWY_TERRAIN_ALL_PIECES_RETRIEVED;
			ReliefStats.Instance.HAS_ACCESS_TO_SNOWY_TERRAIN = true;
		}
	}


	void updateProgressScubaGear(int id) {
		if (id <= ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT) {
			ReliefStats.Instance.underwaterTerrainPiecesFound [0] = true;
		}
		ReliefStats.Instance.currentUnderwaterTerrainProgress++;

		if (ReliefStats.Instance.currentUnderwaterTerrainProgress < ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT) {
			piecePickupProgress.text = System.String.Format(ReliefStats.Instance.UNDERWATER_TERRAIN_PIECE_RETRIEVED, ReliefStats.Instance.currentUnderwaterTerrainProgress) ;
		} else {
			piecePickupProgress.text = ReliefStats.Instance.UNDERWATER_TERRAIN_ALL_PIECES_RETRIEVED;
				ReliefStats.Instance.HAS_ACCESS_TO_UNDERWATER_TERRAIN = true;
		}
	}

	//Precondition: works for names of format: type#id
	string parseType(string name) {
		string type = "";
		foreach (char c in name) {
			if (c == '#') {
				break;
			} else {
				type += c;
			}
		}
		return type;
	}

	//Precondition: works for names of format: type#id
	int parseID(string name) {
		string id = "";
		int idInt = 0;
		bool separatorFound = false;
		foreach (char c in name) {
			if (c == '#') {
				separatorFound = true;
			} else if (separatorFound) {
				id += c;
			}
		}
		int.TryParse(name, out idInt);
		return idInt;
	}

	void OnControllerColliderHit(ControllerColliderHit hit) {
		showPiecePickupProgress (hit.gameObject.tag, hit.gameObject);
	}
}
