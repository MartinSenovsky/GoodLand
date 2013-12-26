using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public static int maxSpeed = 3;

    public Rigidbody2D body;
    public int flyForce = 20;
    public float size = 1;
    public int rotationSpeed = 0;
    public int player = 1;
    public Color color = Color.white;

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

        // fixed rotation
        body.angularVelocity = rotationSpeed;

        // move forward
        body.AddForce(Vector2.right * 5);

        if (body.velocity.x > maxSpeed)
        {
            body.velocity = new Vector2(maxSpeed, body.velocity.y);
        }


        // kill if out of camera
        if (Camera.main.WorldToScreenPoint(transform.position).x < 20)
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

    static public void FlyUp(int player)
    {
        for (int i = 0; i < CameraController.instance.players[player].Count; i++)
        {
            CameraController.instance.players[player][i].body.AddForce(Vector2.up * CameraController.instance.players[player][i].flyForce);
        }
    }

    public void ShowKillAnim()
    {
        GameObject explosion = (GameObject)Instantiate(Resources.Load("Explosion2"));
        (explosion.GetComponent<ExplosionColor>() as ExplosionColor).SetColor(color);
        explosion.transform.position = transform.position;
    }

    public void Kill()
    {
        CameraController.instance.RemovePlayer(this);
        Destroy(gameObject);
    }

    internal void SetRotation(int amount)
    {
        for (int i = 0; i < CameraController.instance.players[player].Count; i++)
        {
            CameraController.instance.players[player][i].rotationSpeed += amount;
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

    void OnCollisionEnter2D(Collision2D col)
    {
        // crush by extreme force
        float force = Mathf.Abs(Vector3.Dot(col.contacts[0].normal, col.relativeVelocity) * body.mass);

        if (force > 10)
        {
            Kill();
            ShowKillAnim();
        }
    }
}
 