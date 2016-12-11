using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class damageScript : MonoBehaviour {
	
	[SerializeField] GameObject damageSpawnPoint;
	[SerializeField] Text damageText;
	List<GameObject> damageTexts;
	List<Animator> animators;

	Color red = new Color();
	Color yellow = new Color();
	Color green = new Color();
	Color blue = new Color();
	Color pink = new Color();
	Color black = new Color();


	void Start () {
		ColorUtility.TryParseHtmlString ("#B71D1DFF", out red);
		ColorUtility.TryParseHtmlString ("#CBCE00FF", out yellow);
		ColorUtility.TryParseHtmlString ("#10BD00FF", out green);
		ColorUtility.TryParseHtmlString ("#1D1EB7FF", out blue);
		ColorUtility.TryParseHtmlString ("#CE2D87FF", out pink);
		ColorUtility.TryParseHtmlString ("#303030FF", out black);

		damageTexts= new List<GameObject>();
		animators = new List<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.Z)) {
//			takeDamage( Random.Range(10,200) ,"blue", gameObject.transform.position);
//		}

		for (int i=0; i<damageTexts.Count; i++) {
			if (animators[i].GetCurrentAnimatorStateInfo(0).IsName ("done")) {
				GameObject temp = damageTexts[i];
				damageTexts.RemoveAt(i);
				animators.RemoveAt(i);
				GameObject.Destroy (temp);
			}
		}
	}

	public void takeDamage(float dmg, string color, Vector3 position){

		damageText.text = ((int)dmg).ToString();
		damageText.gameObject.SetActive (true);
		if (color == "red") { damageText.color=red; }
		else if (color == "yellow") { damageText.color=yellow; }
		else if (color == "green") { damageText.color=green; }
		else if (color == "blue") { damageText.color=blue; }
		else if (color == "pink") { damageText.color=pink; }
		if (color == "black") { damageText.color=black; }

		GameObject tempText = Instantiate(damageSpawnPoint, position, Quaternion.identity) as GameObject;
		tempText.transform.SetParent(GameObject.Find("Canvas").transform, false);

		damageTexts.Add (tempText);
		animators.Add (tempText.transform.FindChild("damageText").GetComponent<Animator>());
	}


}
