using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTopDown : MonoBehaviour {
    [SerializeField]
    float speed = 1.0f;
	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            collision.gameObject.GetComponent<Stats>().TakeDamage(GetComponent<Stats>().attack_);
        }
        if (collision.gameObject.layer == 9)
        {
            GetComponent<Stats>().TakeDamage(collision.gameObject.GetComponent<BulletScript>().damage_);
        }
    }

    // Update is called once per frame
    void Update () {
        var dir = GameObject.Find("Player").transform.position - transform.position;
        GetComponent<Rigidbody2D>().velocity = dir.normalized * speed;
	}
}
