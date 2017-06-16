using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardObject : MonoBehaviour {


    public Card me;
    public HandManager mHandManager = null;

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        //Debug.Log("I HAVE BEEN CLICKED");
        mHandManager.SelectCard(this);
    }

    public void Load(Card c, HandManager hm)
    {
        mHandManager = hm;
        me = c;
        gameObject.GetComponent<SpriteRenderer>().sprite = me.mCardSprite;
        //gameObject.GetComponent<SpriteRenderer>().color = new Color(Random.Range(0, 1.0f), Random.Range(0, 1.0f), Random.Range(0, 1.0f), 1);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
