using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    //Attributes
    private GameObject holder;
    private Rigidbody2D rBody;
    private float offsetX = 1;
    private float offsetY = .25f;

    //properties
    public GameObject Holder
    {
        get { return holder; }
        set { holder = value; }
    }

	// Use this for initialization
	void Start () {
        rBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        if (holder != null)
        {
            if (holder.GetComponent<Player>().FacingLeft)//facing left
            {
                transform.position = new Vector3(holder.transform.position.x + offsetX, holder.transform.position.y + offsetY, -1);
                transform.rotation = Quaternion.Euler(0, 0, -78);
            }
            else//facing right
            {
                transform.position = new Vector3(holder.transform.position.x - offsetX, holder.transform.position.y + offsetY, -1);
                transform.rotation = Quaternion.Euler(0, 180, -78);
            }
        }

	}

    //when the key is just picked up
    public void pickedUp()
    {
        GetComponent<Rigidbody2D>().Sleep();
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().sortingOrder = 2;
        transform.rotation = Quaternion.Euler(0,0,-90);

    }

    public void drop()
    {
        GetComponent<Rigidbody2D>().WakeUp();
        GetComponent<BoxCollider2D>().enabled = true;
        GetComponent<SpriteRenderer>().sortingOrder = 0;
    }
}
