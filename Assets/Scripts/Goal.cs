using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

    ///attributes
    [SerializeField] private Color rangerColor;
    private Rigidbody2D rBody;

    ///Properties
    public Color RangerColor
    {
        get { return rangerColor; }
        set { rangerColor = value; }
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if(rangerColor != GetComponent<SpriteRenderer>().color)
        {
            GetComponent<SpriteRenderer>().color = new Color(rangerColor.r, rangerColor.g, rangerColor.b, 1f);
        }
	}
}
