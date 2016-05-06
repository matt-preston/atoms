using UnityEngine;
using System.Collections;

public class AtomCellHandler : MonoBehaviour {

	public enum Position { TOP, TOP_LEFT, LEFT, BOTTOM_LEFT, BOTTOM, BOTTOM_RIGHT, RIGHT, TOP_RIGHT, NORMAL}

	public Position position = Position.NORMAL;

	public Sprite atom0;
	public Sprite atom1;
	public Sprite atom2;
	public Sprite atom3;
	public Sprite atom4;

	public int count = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		Debug.Log ("on mouse down");
		count = (count + 1) % 5;

		SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

		if (count == 0) {
			spriteRenderer.sprite = atom0;
		} else if (count == 1) {
			spriteRenderer.sprite = atom1;
		} else if (count == 2) {
			spriteRenderer.sprite = atom2;
		} else if (count == 3) {
			spriteRenderer.sprite = atom3;
		} else {
			spriteRenderer.sprite = atom4;
		}
	}

}
