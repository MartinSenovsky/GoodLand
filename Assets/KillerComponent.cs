using UnityEngine;
using System.Collections;

public class KillerComponent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            collision.collider.gameObject.GetComponent<PlayerController>().Kill();
            collision.collider.gameObject.GetComponent<PlayerController>().ShowKillAnim();
        }
    }
}
