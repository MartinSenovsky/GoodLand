using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public List<PlayerController> players;

    public static CameraController instance;

    public PlayerController first;

	// Use this for initialization
	void Start () {
        instance = this;

	    players = new List<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = 0;
        
        for (int i = 0; i < players.Count; i++)
        {
            if (players[i].transform.position.x > x)
            {
                first = players[i];
                x = first.transform.position.x;
            }
        }


        transform.position = new Vector3(x, first.transform.position.y, -10);
	}
}
