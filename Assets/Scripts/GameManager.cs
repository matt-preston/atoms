using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	public GameObject[,] cells;

	void Awake() {
		if (!instance) {
			instance = gameObject.GetComponent<GameManager> ();
			cells = new GameObject[8, 8];
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void RegisterCell(GameObject cell, int row, int column) {
		Debug.Log ("Registering cell: " + row + "x" + column);

		if (cells [row, column]) {
			Debug.LogError ("Duplicate cell at: " + row + "x" + column);
		}

		cells [row, column] = cell;
	}
}
