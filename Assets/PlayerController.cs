using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    Rigidbody2D body;
    public int flyForce;
    public KeyCode flyKey;
    public float size = 1;

	// Use this for initialization
	void Start () {
        body = GetComponent<Rigidbody2D>();
        gameObject.tag = "Player";

        transform.localScale = new Vector3(0.1f, 0.1f, 0.0f);

        CameraController.instance.players.Add(this);

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(flyKey))
        {
            body.AddForce(Vector2.up * flyForce);
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
        if (body.velocity.x < 10)
        {
            body.AddForce(Vector2.right);
        }
	}

    public void Kill()
    {
        CameraController.instance.players.Remove(this);
        Destroy(gameObject);
    }
}
