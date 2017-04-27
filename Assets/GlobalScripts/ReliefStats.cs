using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReliefStats : MonoBehaviour {
	//global statistics for game progress
	public static int SNOWY_TERRAIN_MAX_COLLECT = 5;
	public static int UNDERWATER_TERRAIN_MAX_COLLECT = 5;
	public bool HAS_ACCESS_TO_SNOWY_TERRAIN = false;
	public bool HAS_ACCESS_TO_UNDERWATER_TERRAIN = false;
	public int currentSnowyTerrainProgress = 0;
	public int currentUnderwaterTerrainProgress = 0;
	public bool[] snowyTerrainPiecesFound = new bool[ReliefStats.SNOWY_TERRAIN_MAX_COLLECT];
	public bool[] underwaterTerrainPiecesFound = new bool[ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT];


	//global strings for UI text displays
	public string SNOWY_TERRAIN_PIECE_RETRIEVED = "Winter coat piece retrieved! {0} of " + ReliefStats.SNOWY_TERRAIN_MAX_COLLECT.ToString ();
	public string UNDERWATER_TERRAIN_PIECE_RETRIEVED = "Scuba gear piece retrieved! {0} of " + ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT.ToString ();
	public string SNOWY_TERRAIN_ALL_PIECES_RETRIEVED = "Congratulations! You have collected all pieces of the winter coat. You can access Frigid Cliff.";
	public string UNDERWATER_TERRAIN_ALL_PIECES_RETRIEVED = "Congratulations! You have collected all pieces of the scuba gear. You can access Barnacle Waters.";
	public string NO_ACCESS_SNOWY_TERRAIN = "You have {0} winter coat pieces left before you can access Frigid Cliff.";
	public string NO_ACCESS_UNDERWATER_TERRAIN = "You have {0} scuba gear pieces left before you can access Barnacle Waters.";
	public string ACCESS_SNOWY_TERRAIN = "Access Granted! You are using your snow coat to access Frigid Cliff...";
	public string ACCESS_UNDERWATER_TERRAIN = "Access Granted! You are using your scuba gear to access Barnacle Waters...";

	//user specific credentials
	public string username = null; //nil for local-dev mode

	//static instance of this class to reset vars after load
	public static ReliefStats Instance;

	void Start()
	{
		ReliefStats.Instance = this;
		ReliefStats.Instance.snowyTerrainPiecesFound = new bool[ReliefStats.SNOWY_TERRAIN_MAX_COLLECT];
		ReliefStats.Instance.underwaterTerrainPiecesFound = new bool[ReliefStats.UNDERWATER_TERRAIN_MAX_COLLECT];

	}
}
