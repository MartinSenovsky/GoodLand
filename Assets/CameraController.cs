using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

    public List<List<PlayerController>> players;

    public static CameraController instance;

    public PlayerController first;
    public float totalX;

    private bool moveEnabled = true;

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
        if (moveEnabled)
        {
            // move camera

            float x = 0;
            bool end = true;
            // iterate players
            for (int j = 0; j < players.Count; j++)
            {
                for (int i = 0; i < players[j].Count; i++)
                {
                    end = false;
                    if (players[j][i].transform.position.x > x)
                    {
                        first = players[j][i];
                        x = first.transform.position.x;
                    }
                }
            }

            if (end)
            {
                EndGame();
                return;
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
	}

    private void EndGame()
    {
        // end game
        Debug.Log("END GAME");

        Stop();
    }

    internal void AddPlayer(PlayerController p)
    {
       players[p.player].Add(p);
    }

    internal void RemovePlayer(PlayerController p)
    {
        players[p.player].Remove(p);
    }

    public void Stop()
    {
        moveEnabled = false;
    }
}
