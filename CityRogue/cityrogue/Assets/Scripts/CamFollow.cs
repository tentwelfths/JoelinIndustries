using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {
    GameObject player;
    [SerializeField]
    float boundUpper = 1.0f;
    [SerializeField]
    float boundLower = 1.0f;
    [SerializeField]
    float boundLeft = 1.0f;
    [SerializeField]
    float boundRight = 1.0f;
    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 newTrans = Vector3.zero;
        newTrans.z = transform.position.z;
        var pPos = GameObject.Find("Player").transform.position;
        if((pPos.y + GetComponent<Camera>().orthographicSize < boundUpper) && (pPos.y - GetComponent<Camera>().orthographicSize > boundLower))
        {
            newTrans.y = pPos.y;
        }
        else
        {
            newTrans.y = transform.position.y;
        }
        if ((pPos.x + GetComponent<Camera>().orthographicSize < boundRight) && (pPos.x - GetComponent<Camera>().orthographicSize > boundLeft))
        {
            newTrans.x = pPos.x;
        }
        else
        {
            newTrans.x = transform.position.x;
        }
        transform.position = newTrans;
	}
}
