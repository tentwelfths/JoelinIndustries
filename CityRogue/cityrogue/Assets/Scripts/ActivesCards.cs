using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivesCards : MonoBehaviour {
    [SerializeField]
    float coolDown = 1.0f;
    float timeTillUse;
	// Use this for initialization
	void Start () {
        timeTillUse = coolDown;

    }
	public void Activate()
    {

    }
	// Update is called once per frame
	void Update () {
		if(timeTillUse >= coolDown)
        {
            if(Input.GetButtonDown("A"))
            {
                Activate();
                timeTillUse = 0.0f;
            }
        }
        else
        {
            timeTillUse += Time.deltaTime;
        }
	}
}
