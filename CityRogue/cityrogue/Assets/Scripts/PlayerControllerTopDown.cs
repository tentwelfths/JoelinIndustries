using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum State { NORMAL, DASH}
public class PlayerControllerTopDown : MonoBehaviour {
    [SerializeField]
    float speed_ = 1.0f;
    [SerializeField]
    float bulletSpeed_ = 1.0f;
    [SerializeField]
    float shotCD = 0.3f;
    float shotTime = 0.3f;
    State curState = State.NORMAL;
    [SerializeField]
    float dashCD = 0.5f;
    float dashTimer = 0.5f;
    [SerializeField]
    float dashDur = 0.2f;
    float dashDurTimer = 0.0f;
    Vector2 dashDir = Vector2.zero;
    [SerializeField]
    float dashSpeedMax = 2.0f;
    [SerializeField]
    float dashSpeedMin = 0.1f;
    float dashSpeed;
    float swap = 1.0f;

    // Use this for initialization
    void Start () {
        dashSpeed = dashSpeedMax;

    }
	
	// Update is called once per frame
	void Update () {
        if(curState == State.NORMAL)
        {
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

            if (shotCD < shotTime)
            {
                bool spawnBullet = false;
                Vector2 bulletVel = Vector2.zero;
                var bulletX = Input.GetAxis("RightStickX");
                var bulletY = Input.GetAxis("RightStickY");
                if (bulletX > 0.1 || bulletX < -0.1)
                {
                    bulletVel.x = bulletX;
                    spawnBullet = true;
                }
                if (bulletY > 0.1 || bulletY < -0.1)
                {
                    bulletVel.y = bulletY;
                    spawnBullet = true;
                }
                if (spawnBullet)
                {
                    var bul = Instantiate(GameObject.Find("Bullet"));
                    Vector3 bulTrans = Vector3.zero;
                    bulTrans.x = bulletVel.x;
                    bulTrans.y = bulletVel.y;
                    Vector3 offset = Vector3.Cross(bulTrans, Vector3.forward);
                    bul.transform.position = transform.position + offset*0.25f*swap;
                    swap = -swap;
                    bul.GetComponent<Rigidbody2D>().velocity = bulletVel.normalized * bulletSpeed_;
                    bul.GetComponent<BulletScript>().damage_ = GetComponent<Stats>().attack_;
                    shotTime = 0.0f;
                }
            }
            else
            {
                shotTime += Time.deltaTime;
            }
            if(dashCD <= dashTimer)
            {
                //if (Input.GetButton("Fire1"))
                //{
                //    curState = State.DASH;
                //    dashDir = -GetComponent<Rigidbody2D>().velocity;
                //    gameObject.layer = 10;
                //    dashTimer = 0.0f;
                //}
                if (Input.GetButton("Fire2") || Input.GetButton("Fire1"))
                {
                    curState = State.DASH;
                    dashDir = GetComponent<Rigidbody2D>().velocity;
                    gameObject.layer = 10;
                    dashTimer = 0.0f;
                    dashSpeed = dashSpeedMax;
                }
            }
            else
            {
                dashTimer += Time.deltaTime;
            }
        }
        else if(curState == State.DASH)
        {
            if(dashDur > dashDurTimer)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                GetComponent<Rigidbody2D>().velocity = dashDir * dashSpeed;
                dashDurTimer += Time.deltaTime;
                dashSpeed -= Time.deltaTime * (dashSpeedMax - dashSpeedMin)/dashDur;
            }
            else if(dashDur <= dashDurTimer)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                gameObject.layer = 8;
                dashDurTimer = 0.0f;
                curState = State.NORMAL;
            }
        }
    }
}
