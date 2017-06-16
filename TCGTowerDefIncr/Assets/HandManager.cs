using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour {

    List<CardObject> hand = new List<CardObject>();
    public CardManager mCardManager = null;
    public CardObject mCardPrefab = null;
	// Use this for initialization
	void Start () {
		
	}

    void PositionHand()
    {
        for (int i = 0; i < hand.Count; ++i)
        {
            float xPos = (((hand.Count) / 2.0f) - i) * 1.1f;
            hand[i].transform.position = new Vector3(xPos, -3, 0);
        }

    }

    public void SelectCard(CardObject c)
    {
        mCardManager.SelectCard(c);
        
    }

    public void RemoveCardFromHand(Card c)
    {
        for(int i = 0; i < hand.Count; ++i)
        {
            if(hand[i].me.mID == c.mID)
            {

                //Debug.Log("FOUND MATCH AND KILLING IT");
                CardObject toDestroy = hand[i];
                hand.RemoveAt(i);

                Destroy(toDestroy.gameObject);
                i = 0;
            }
        }
        PositionHand();
    }

    public void DrawCard()
    {
        
        Card c = mCardManager.DrawCard();
        int index = hand.Count;
        hand.Add(GameObject.Instantiate<CardObject>(mCardPrefab));
        hand[index].GetComponent<CardObject>().Load(c, this);
        PositionHand();
    }

    void DrawFirstHand()
    {
        mCardManager.StartRound();
        for(int i =0; i < 5; ++i)
        {
            DrawCard();
        }
    }
    bool b = false;
    // Update is called once per frame
    void Update () {
        
        if(b == false)
        {
            //Debug.Log("DRAWING FIRST HAND");
            DrawFirstHand();
            b = true;
        }
	}
}
