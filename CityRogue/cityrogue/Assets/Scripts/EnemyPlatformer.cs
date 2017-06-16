using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlatformer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Stats>().TakeDamage(GetComponent<Stats>().attack_);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
