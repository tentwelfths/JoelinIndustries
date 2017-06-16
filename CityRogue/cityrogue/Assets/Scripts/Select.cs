using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour {
    [SerializeField]
    float speed_ = 1.0f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 newVel = Vector2.zero;
        var newX = Input.GetAxis("Horizontal");
        var newY = Input.GetAxis("Vertical");
        if (newX > 0.1 || newX < -0.1)
        {
            newVel.x = newX;
        }
        if (newY > 0.1 || newY < -0.1)
        {
            newVel.y = newY;
        }
        GetComponent<Rigidbody2D>().velocity = newVel * speed_;
    }
}
