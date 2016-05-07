using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public enum Position { TOP, TOP_LEFT, LEFT, BOTTOM_LEFT, BOTTOM, BOTTOM_RIGHT, RIGHT, TOP_RIGHT, NORMAL}

    public static GameManager instance;

    public float speed = 0.2f;

	public Atom[,] atoms;
    private Stack<Atom> overCapacityAtoms = new Stack<Atom>();

    private float timeToProcessAtoms = -1;

	void Awake() {
		if (!instance) {
			instance = gameObject.GetComponent<GameManager> ();
			atoms = new Atom[8, 8];
		}
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (timeToProcessAtoms > 0 && Time.time > timeToProcessAtoms) {
            timeToProcessAtoms = -1;
            ProcessOverCapacityAtoms ();
        }
	}

	public Position RegisterCell(Atom atom, int row, int column) {
		Debug.Log ("Registering cell: " + row + "x" + column);

		if (atoms [row, column]) {
			Debug.LogError ("Duplicate cell at: " + row + "x" + column);
		}

		atoms [row, column] = atom;

        return Position.NORMAL;
	}

	public void Select(Atom atom) {
		Debug.Log ("Selected Atom: " + atom);

		// Is valid selection?
        // Start Move

		atom.Increment ();

        if (atom.OverCapacity ()) {
            overCapacityAtoms.Push(atom);
            timeToProcessAtoms = Time.time + speed; 
        }

        // End Move
	}

    private void ProcessOverCapacityAtoms() {
        if (overCapacityAtoms.Count > 0) {
            Atom next = overCapacityAtoms.Pop ();
            next.Explode ();

            foreach (Atom neighbour in Neighbours(next)) {
                neighbour.Increment ();
                if (neighbour.OverCapacity ()) {
                    overCapacityAtoms.Push(neighbour);
                }
            }
        }

        if (overCapacityAtoms.Count > 0) {
            timeToProcessAtoms = Time.time + speed;
        } else {
            // End Move
        }
    }

    private List<Atom> Neighbours(Atom atom) {
        // TODO
        List<Atom> result = new List<Atom> ();
        result.Add (atoms [atom.row, atom.column - 1]);
        result.Add (atoms [atom.row, atom.column + 1]);
        result.Add (atoms [atom.row - 1, atom.column]);
        result.Add (atoms [atom.row + 1, atom.column]);
        return result;
    }
}
