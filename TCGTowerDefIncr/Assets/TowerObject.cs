using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    public void Load(Card c)
    {
        //Debug.Log("LOADING TOWER");
        gameObject.GetComponent<SpriteRenderer>().sprite = c.mGridSprite;
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f), 1);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
