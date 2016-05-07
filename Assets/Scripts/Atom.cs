using UnityEngine;
using System.Collections;

public class Atom : MonoBehaviour {

	public Sprite atom0;
	public Sprite atom1;
	public Sprite atom2;
	public Sprite atom3;
	public Sprite atom4;

	public int row;
	public int column;

	public int count = 0;

    private GameManager.Position position;

	// Use this for initialization
	void Start () {
		position = GameManager.instance.RegisterCell (this, row, column);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		GameManager.instance.Select (this);
	}

	public void Increment() {
		count++;

        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();

		switch (count) {
            case 1:
                spriteRenderer.sprite = atom1;
                Debug.Log ("Updating to 1");
                break;
            case 2:
                spriteRenderer.sprite = atom2;
                Debug.Log ("Updating to 2");
                break;
            case 3:
                spriteRenderer.sprite = atom3;
                Debug.Log ("Updating to 3");
                break;
            default:
                spriteRenderer.sprite = atom4;
                Debug.Log ("Updating to 4");
                break;
        }
    }

    public bool OverCapacity() {
        switch (position) {
        case GameManager.Position.TOP_LEFT:
        case GameManager.Position.TOP_RIGHT:
        case GameManager.Position.BOTTOM_LEFT:
        case GameManager.Position.BOTTOM_RIGHT:
            return count > 1;
        case GameManager.Position.TOP:
        case GameManager.Position.RIGHT:
        case GameManager.Position.BOTTOM:
        case GameManager.Position.LEFT:
            return count > 2;
        default:
            return count > 3;
        }    
    }

    public void Explode() {
        count = 0;
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
        spriteRenderer.sprite = atom0;
        Debug.Log ("Exploded");
    }

}
