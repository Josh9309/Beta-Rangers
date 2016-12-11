using UnityEngine;
using System.Collections;

public class Killzone : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.tag == "Player")
        {
            thing.GetComponent<Player>().DestroyRanger();
        }
        else if (thing.tag == "Key")
        {
            thing.GetComponent<Key>().droppedOffStage();
            thing.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            thing.transform.position = GameObject.FindGameObjectWithTag("Key Spawn Point").transform.position;
        }
        else if (thing.tag == "Black Hole" || thing.tag == "Stat Dart")
        {
            DestroyObject(thing.gameObject);
        }
    }
}
