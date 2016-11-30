﻿using UnityEngine;
using System.Collections;

public class RangerChoice : MonoBehaviour {
    #region Attributes
    [SerializeField] private bool available = true;
    [SerializeField] private Sprite rangerSprite;
    [SerializeField] private Player.RangerType rangerType;
    [SerializeField] private GameObject selectedSymbol;
    [SerializeField] private GameObject unavailableSymbol;
    #endregion

    #region Properties
    public bool Available
    {
        get { return available; }
    }

    #endregion

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

    #region Methods
    public void SetAvailable()
    {
        available = true;
        unavailableSymbol.SetActive(false);
    }

    public void SetUnavailable()
    {
        available = false;
        unavailableSymbol.SetActive(true);
    }

    public void Selected(SpriteRenderer player, GameObject playerGroup)
    {
        player.sprite = rangerSprite;
        selectedSymbol.SetActive(true);

        if (!available)
        {
            playerGroup.transform.FindChild("Taken").gameObject.SetActive(true);
        }
    }

    public void Unselected(GameObject playerGroup)
    {
        selectedSymbol.SetActive(false);
        if (!available)
        {
            playerGroup.transform.FindChild("Taken").gameObject.SetActive(false);
        }
    }

    #endregion
}
