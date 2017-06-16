using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    // Use this for initialization
    [System.NonSerialized]
    public int damage_ = 0;
    void Start () {
        GetComponent<Rigidbody2D>().gravityScale = 0.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
