using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerPlatformer : MonoBehaviour {
    [SerializeField]
    float speed_ = 1.0f;
    [SerializeField]
    float jumpHeight_ = 5.0f;
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
    bool canJump = false;
    // Use this for initialization
    void Start () {
        dashSpeed = dashSpeedMax;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 12)
        {
            canJump = true;
        }
    }

    // Update is called once per frame
    void Update () {
        var rig = GetComponent<Rigidbody2D>();
        if (curState == State.NORMAL)
        {
            Vector2 newVel = Vector2.zero;
            var newX = Input.GetAxis("Horizontal");
            
            newVel.y = rig.velocity.y;
            if (newX > 0.1 || newX < -0.1)
            {
                if (newX > 0.8f)
                {
                    newVel.x = 1.0f;
                }
                else if (newX < -0.8f)
                {
                    newVel.x = -1.0f;
                }
                else
                {
                    newVel.x = newX;
                }

            }
            if (canJump && Input.GetButtonDown("A"))
            {
                newVel.y = jumpHeight_;
                canJump = false;
            }
            newVel.x *= speed_;
            rig.velocity = (newVel);
            if (dashCD <= dashTimer)
            {
                if (Input.GetButton("Fire1"))
                {
                    curState = State.DASH;
                    dashDir = Vector2.right;
                    gameObject.layer = 10;
                    dashTimer = 0.0f;
                    dashSpeed = dashSpeedMax;
                }
                else if (Input.GetButton("Fire2"))
                {
                    curState = State.DASH;
                    dashDir = -Vector2.right;
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
        else if (curState == State.DASH)
        {
            if (dashDur > dashDurTimer)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                rig.velocity = dashDir * dashSpeed;
                dashDurTimer += Time.deltaTime;
                dashSpeed -= Time.deltaTime * (dashSpeedMax - dashSpeedMin) / dashDur;
            }
            else if (dashDur <= dashDurTimer)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                gameObject.layer = 8;
                dashDurTimer = 0.0f;
                curState = State.NORMAL;
            }
        }

    }
}
