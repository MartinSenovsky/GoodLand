using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public List<PlayerController> players;

    public static CameraController instance;

    public PlayerController first;
    public float totalX;

	// Use this for initialization
	void Start () {
        instance = this;

	    players = new List<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = 0;
        
        // get first
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].transform.position.x > x)
            {
                first = players[i];
                x = first.transform.position.x;
            }
        }


        // move slowly forward
        totalX += 0.02f;

        // 
        if (x > totalX)
        {
            totalX = x;
        }


        transform.position = new Vector3(totalX, first.transform.position.y, -10);
	}
}
