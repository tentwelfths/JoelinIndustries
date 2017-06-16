using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour {
    public int maxHealth_ = 1;
    int curHealth = 0;
    public int attack_ = 1;
    // Use this for initialization
    void Start () {
        curHealth = maxHealth_;
    }
	public void TakeDamage(int damage)
    {
        curHealth -= damage;
    }
	// Update is called once per frame
	void Update () {
		if(curHealth <= 0)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0.0f;
            GetComponent<SpriteRenderer>().color = Color.green;
            var enemy = GetComponent<EnemyTopDown>();
            if(enemy)
            {
                enemy.enabled = false;
            }
            else
            {
                var player = GetComponent<PlayerControllerTopDown>();
                if(player)
                {
                    player.enabled = false;
                }
            }
        }
	}
}
