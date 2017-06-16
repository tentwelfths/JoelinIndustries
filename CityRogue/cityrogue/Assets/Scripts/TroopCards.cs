using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroopCards : MonoBehaviour {
    [SerializeField]
    int maxHealth = 1;
    [System.NonSerialized]
    public int curHealth;
    [SerializeField]
    int attack = 1;
    [SerializeField]
    int defense = 1;
    [SerializeField]
    int cost = 1;
    [SerializeField]
    IncomeType costType;
    // Use this for initialization
    void Start () {
        curHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
