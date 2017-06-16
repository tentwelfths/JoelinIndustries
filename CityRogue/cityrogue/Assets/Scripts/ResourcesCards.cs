using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum IncomeType { GOLD, MAGIC, WOOD, IRON, BONES}

public class ResourcesCards : MonoBehaviour {
    [SerializeField]
    IncomeType resourceGiven;
    [SerializeField]
    int amountGivenPerUpdate = 1;
    [SerializeField]
    float updateTime = 1.0f;
    float timeTillUpdate;
	// Use this for initialization
	void Start () {
        timeTillUpdate = updateTime;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
