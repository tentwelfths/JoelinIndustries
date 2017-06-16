using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTown : MonoBehaviour {
    [SerializeField]
    float gridStart = -0.8f;
    [SerializeField]
    GameObject Spawn;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < 3; ++i)
        {
            for (int j = 0; j < 3; ++j)
            {
                var build = Instantiate(Spawn);
                Vector3 newPos = Vector3.zero;
                newPos.x = gridStart - (gridStart * (j));
                newPos.y = gridStart - (gridStart * (i));
                build.transform.position = newPos;
                var townStuff = GameObject.Find("TownInformation").GetComponent<TownData>();
                var building = build.GetComponent<Building>();
                var slot = townStuff.buildingData[j + i * 3];
                building.type_ = slot.type_;
                var rend = building.GetComponent<SpriteRenderer>();
                if (building.type_ == BuildingType.NONE)
                {
                    rend.color = Color.green;
                }
                else if (building.type_ == BuildingType.BLACKSMITH)
                {
                    rend.color = Color.red;
                }
                else if (building.type_ == BuildingType.HOUSE)
                {
                    rend.color = Color.blue;
                }
                else if (building.type_ == BuildingType.TOWER)
                {
                    rend.color = Color.yellow;
                }
            }
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
