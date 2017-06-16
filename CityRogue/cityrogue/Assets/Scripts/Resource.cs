using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ResourceType { MONEY, PEOPLE }
public class Resource : MonoBehaviour {
    [SerializeField]
    ResourceType type_ = ResourceType.MONEY;
    [SerializeField]
    int amount = 1;
    // Use this for initialization
    void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            var townStuff = GameObject.Find("TownInformation").GetComponent<TownData>();
            if(type_ == ResourceType.MONEY)
            {
                townStuff.totalMoney += amount;
                townStuff.curMoney += amount;
            }
            if(type_ == ResourceType.PEOPLE)
            {
                townStuff.populationTotal += amount;
            }
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
