using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupShape : MonoBehaviour {
	
	public Text piecePickupProgress;

	void Start () {
		piecePickupProgress.text = "";
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

		Invoke ("eraseCurrentStatus", 6); //delays erase for three seconds
	}
		
	void eraseCurrentStatus() {
		piecePickupProgress.text = "";
	}
		
	void updateProgressWinterCoat(int id) {
		if (id <= ReliefStats.SNOWY_TERRAIN_MAX_COLLECT) {
			ReliefStats.snowyTerrainPiecesFound [id] = true;
		}
		ReliefStats.currentSnowyTerrainProgress++;

		if (ReliefStats.currentSnowyTerrainProgress < ReliefStats.SNOWY_TERRAIN_MAX_COLLECT) {
			piecePickupProgress.text = System.String.Format(ReliefStats.SNOWY_TERRAIN_PIECE_RETRIEVED, ReliefStats.currentSnowyTerrainProgress);
		} else {
			piecePickupProgress.text = ReliefStats.SNOWY_TERRAIN_ALL_PIECES_RETRIEVED;
			ReliefStats.HAS_ACCESS_TO_SNOWY_TERRAIN = true;
		}
	}


	void updateProgressScubaGear(int id) {
		if (id <= ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT) {
			ReliefStats.underwaterTerrainPiecesFound [id] = true;
		}
		ReliefStats.currentUnderwaterTerrainProgress++;

		if (ReliefStats.currentUnderwaterTerrainProgress < ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT) {
			piecePickupProgress.text = System.String.Format(ReliefStats.UNDERWATER_TERRAIN_PIECE_RETRIEVED, ReliefStats.currentUnderwaterTerrainProgress) ;
		} else {
			piecePickupProgress.text = ReliefStats.UNDERWATER_TERRAIN_ALL_PIECES_RETRIEVED;
				ReliefStats.HAS_ACCESS_TO_UNDERWATER_TERRAIN = true;
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
