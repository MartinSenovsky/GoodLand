using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public List<List<PlayerController>> players;

    public static CameraController instance;

    public PlayerController first;
    public float totalX;

	// Use this for initialization
	void Start () {
        instance = this;

        players = new List<List<PlayerController>>();
        
        players.Add(new List<PlayerController>());
        players.Add(new List<PlayerController>());
        players.Add(new List<PlayerController>());
	}
	
	// Update is called once per frame
	void Update () {
        
        float x = 0;
        
        // get first
        for (int j = 0; j < players.Count; j++)
        {
            for (int i = 0; i < players[j].Count; i++)
            {
                if (players[j][i].transform.position.x > x)
                {
                    first = players[j][i];
                    x = first.transform.position.x;
                }
            }
        }


        // move slowly forward
        totalX += 0.02f;

        // fast forward if needed
        if (x > totalX)
        {
            totalX = x;
        }

        // move
        transform.position = new Vector3(totalX, first.transform.position.y, -10);
	}

    internal void AddPlayer(PlayerController p)
    {
       players[p.player].Add(p);
    }

    internal void RemovePlayer(PlayerController p)
    {
        players[p.player].Remove(p);
    }
}
