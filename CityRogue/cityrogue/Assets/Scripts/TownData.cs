using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Prototypes { TOPDOWN, PLATFORM, CARD }
public enum BuildingType { NONE, TOWER, HOUSE, BLACKSMITH }

public struct BuildingStats
{
    [System.NonSerialized]
    public BuildingType type_;
    [System.NonSerialized]
    public int maxNumPeople_;

}

public class TownData : MonoBehaviour {
    [SerializeField]
    Prototypes type_ = Prototypes.TOPDOWN;
    [System.NonSerialized]
    public int totalMoney = 0;
    [System.NonSerialized]
    public int curMoney = 0;
    [System.NonSerialized]
    public int gridSize = 3;
    [System.NonSerialized]
    public int populationTotal = 1;
    [System.NonSerialized]
    public int populationHoused = 0;
    [System.NonSerialized]
    public BuildingStats[] buildingData;


    // Use this for initialization
    void Start () {
        buildingData = new BuildingStats[9];

        for (int i = 0; i < 9;++i)
        {
            buildingData[i].type_ = BuildingType.NONE;
            buildingData[i].maxNumPeople_ = 1;
        }
        buildingData[4].type_ = BuildingType.TOWER;
        DontDestroyOnLoad(gameObject);
	}

    public void Load()
    {
        if(type_ == Prototypes.TOPDOWN)
        {
            Application.LoadLevel("Topdown");
        }
        else if(type_ == Prototypes.PLATFORM)
        {
            Application.LoadLevel("Platformer");
        }
    }

    // Update is called once per frame
    void Update () {
        
	}
}


