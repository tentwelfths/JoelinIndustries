using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileObject : MonoBehaviour {


    public GridManager mGridManager = null;

    public int x;
    public int y;

	// Use this for initialization
	void Start () {
		
	}

    public void OnMouseDown()
    {
        mGridManager.Clicked(this);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
