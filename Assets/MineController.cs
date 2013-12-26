using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MineController : MonoBehaviour {

    public int explosionStrength = 100;

    private List<PlayerController> nearby;


	// Use this for initialization
	void Start () {
        nearby = new List<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.CompareTag("Player"))
        {
            Explode();
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController p = collider.gameObject.GetComponent<PlayerController>();
            if (!nearby.Contains(p))
            {
                nearby.Add(p);
                Debug.Log("add");
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController p = collider.gameObject.GetComponent<PlayerController>();
            nearby.Remove(p);
            Debug.Log("remove");
        }
    }

    private void Explode()
    {
        Destroy(gameObject);
        // get all bodies that will be affected by explosion
        for (int i = 0; i < nearby.Count; i++)
        {
            Vector2 force = nearby[i].transform.position - transform.position;            
            force = force * explosionStrength;
            Debug.Log(force.ToString());
            nearby[i].body.AddForce(force);
        }

        // play animation
        GameObject explosion = (GameObject)Instantiate(Resources.Load("Explosion1"));
        //explosion.renderer.sortingLayerName = 
        //explosion.transform.position = transform.position;
    }
}
