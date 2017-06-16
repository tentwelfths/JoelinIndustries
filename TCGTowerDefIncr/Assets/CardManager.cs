using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[Serializable]
public struct NamedImage
{
    public string name;
    public Sprite image;
}

public class CardManager : MonoBehaviour {

    Dictionary<string, Card> baseCards = new Dictionary<string, Card>();
    Dictionary<ulong, Card> collection = new Dictionary<ulong, Card>();
    List<Card> deck =       new List<Card>();
    List<Card> activeDeck = new List<Card>();
    public List<NamedImage> mSprites = new List<NamedImage>();
    Dictionary<string, Sprite> sprites = new Dictionary<string, Sprite>();

    public HandManager mHandManager = null;
    public GameObject mCardDisplay = null;
    public GameObject mSelected = null;
    // Use this for initialization
    void Start () {
        for(int i = 0; i < mSprites.Count; ++i)
        {
            sprites.Add(mSprites[i].name, mSprites[i].image);
        }
        Card c = new Card();
        c.mName = "Basic Tower";
        c.mCardSprite = sprites["BasicTower"];
        c.mGridSprite = c.mCardSprite;
        baseCards.Add(c.mName, c);
        //Load save file
        bool saveLoaded = false;
        //Try and load a save file looooool
        if (!saveLoaded)
        {
            //Create new gamestate by giving them a basic deck
            for(int i = 0; i < 50; ++i)
            {
                Card a = new Card(baseCards["Basic Tower"]);
                ulong newID = 0;
                do
                {
                    newID = Convert.ToUInt64((UnityEngine.Random.Range(0, int.MaxValue)/((double)(int.MaxValue))) * ulong.MaxValue);
                } while (collection.ContainsKey(newID));
                a.mID = newID;
                //Debug.Log("****" + a.mID);
                collection.Add(newID, a);
                //Debug.Log("****" + collection[newID].mID);
                deck.Add(collection[newID]);
                //Debug.Log("****" + deck[deck.Count - 1].mID);
                //Debug.Log("EEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEEE");
            }
        }
	}

    public void SelectCard(CardObject card )
    {
        mSelected = card.gameObject;
        mSelected.GetComponent<SpriteRenderer>().color = new Color(1, 0, 0);
        mCardDisplay.GetComponentInChildren<Image>().sprite = card.me.mCardSprite;
        mCardDisplay.gameObject.SetActive(true);
    }

    public void Deselect()
    {
        mSelected = null;
        mCardDisplay.gameObject.SetActive(false);
    }

    public void CardPlaced()
    {
        mHandManager.RemoveCardFromHand(mSelected.GetComponent<CardObject>().me);
        Deselect();
    }

    public void StartRound()
    {
        activeDeck.Clear();
        for (int i = 0; i < deck.Count; ++i)
        {
            activeDeck.Add(deck[i]);
            //Debug.Log("---Copying over card ID " + deck[i].mID + "\n" +
            //          "---To active deck    ID " + activeDeck[i].mID);
            //Debug.Log(activeDeck.Count);
        }
    }

    public Card DrawCard()
    {
        int index = UnityEngine.Random.Range(0, activeDeck.Count);
        Card toReturn = activeDeck[index];
        //Debug.Log("Drew card with ID: " + toReturn.mID);
        activeDeck.RemoveAt(index);
        //Debug.Log("Card drawn. Deck size remaining is: " + activeDeck.Count + " and actual deck has " + deck.Count + " cards total");
        return toReturn;
    }

    public Card GetCardByName(string name)
    {
        return baseCards[name];
    }

    public Card GetCardByID(ulong ID)
    {
        return collection[ID];
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
