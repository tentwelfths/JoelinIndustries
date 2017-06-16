using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour {
    [System.NonSerialized]
    public BuildingType type_;
    [System.NonSerialized]
    public int maxNumPeople_;
    bool canInteract = false;
    // Use this for initialization
    void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 13)
        {
            canInteract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 13)
        {
            canInteract = false;
        }
    }
    // Update is called once per frame
    void Update () {
		if(canInteract)
        {
            var rend = GetComponent<SpriteRenderer>();
            if(Input.GetButtonDown("A"))
            {
                if(type_ == BuildingType.NONE)
                {
                    rend.color = Color.green;
                }
                else if(type_ == BuildingType.TOWER)
                {
                    var townStuff = GameObject.Find("TownInformation").GetComponent<TownData>();
                    townStuff.Load();
                }
                else if (type_ != BuildingType.NONE)
                {
                    type_ = BuildingType.NONE;
                    maxNumPeople_ = 1;
                    rend.color = Color.green;
                }
            }
            else if(Input.GetButtonDown("X"))
            {
                if (type_ == BuildingType.HOUSE)
                {
                    rend.color = Color.blue;
                }
                else if (type_ == BuildingType.TOWER)
                {

                }
                else if (type_ != BuildingType.HOUSE)
                {
                    type_ = BuildingType.HOUSE;
                    maxNumPeople_ = 1;
                    rend.color = Color.blue;
                }
            }
            else if(Input.GetButtonDown("B"))
            {
                if (type_ == BuildingType.BLACKSMITH)
                {
                    rend.color = Color.red;
                }
                else if (type_ == BuildingType.TOWER)
                {
                    
                }
                else if (type_ != BuildingType.BLACKSMITH)
                {
                    type_ = BuildingType.BLACKSMITH;
                    maxNumPeople_ = 1;
                    rend.color = Color.red;
                }
            }
            else if(Input.GetButtonDown("Y"))
            {

            }
        }
	}
}
