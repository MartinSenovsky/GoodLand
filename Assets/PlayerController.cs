﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D body;
    public int flyForce;
    public KeyCode flyKey;
    public float size = 1;
    public int player = 1;

    private int timeout = -1;
    private Vector2 velocity;
    private float angularVelocity;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        gameObject.tag = "Player";

        transform.localScale = new Vector3(0.1f, 0.1f, 0.0f);
        
        CameraController.instance.AddPlayer(this);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(flyKey))
        {
            body.AddForce(Vector2.up * flyForce);
        }

        if (size <= 0)
        {
            size = 0.1f;
        }

        if(transform.localScale.x < size)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.1f, transform.localScale.x + 0.1f, 0.0f);
        }
        if(transform.localScale.x > size)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.x - 0.1f, 0.0f);
        }

        // fix rotation
        //body.angularVelocity = 0;

        // move forward
        if (body.velocity.x < 2)
        {
            body.AddForce(Vector2.right);
        }

        // kill if out of camera
        if (transform.position.x < CameraController.instance.totalX - (Screen.width / 2) / 100)
        {
            Kill();
        }


        // update to original 
        if (timeout == 0)
        {
            timeout = -1;
            body.angularVelocity = angularVelocity;
            body.velocity = velocity;
        }

        // update after timeout to 
        if (timeout > 0)
        {
            timeout--;
        }
	}

    public void Kill()
    {
        CameraController.instance.RemovePlayer(this);
        Destroy(gameObject);
    }

    internal void SetRotation(float amount)
    {
        for (int i = 0; i < CameraController.instance.players[player].Count; i++)
        {
            CameraController.instance.players[player][i].body.angularVelocity += amount;
        }
    }

    internal void AddSize(float amount)
    {
        for (int i = 0; i < CameraController.instance.players[player].Count; i++)
        {
            CameraController.instance.players[player][i].size += amount;
        }
    }

    internal void ApplySpawn(Vector2 _velocity, float _angularVelocity)
    {
        timeout = 10;
        velocity = _velocity;
        angularVelocity = _angularVelocity;
    }
}
