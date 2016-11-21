using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LoadingScene : MonoBehaviour {

    [SerializeField] private float loadTime = 4.0f;
    [SerializeField] private GameObject continueBtn;
    [SerializeField] private GameObject loadingText;
    [SerializeField] private GameObject loadingShuriken;

    // Use this for initialization
    void Start () {
        StartCoroutine(LoadingGame());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private IEnumerator LoadingGame()
    {
        yield return new WaitForSeconds(loadTime);

        loadingText.SetActive(false);
        loadingShuriken.SetActive(false);

        continueBtn.SetActive(true);
        EventSystem.current.firstSelectedGameObject = continueBtn;
    }
}
