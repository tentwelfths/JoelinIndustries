﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Application.LoadLevel("Town");
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
