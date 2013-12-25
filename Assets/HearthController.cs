using UnityEngine;
using System.Collections;

public class HearthController : MonoBehaviour {

    public int spawnNumber = 1;


	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController p = collider.gameObject.GetComponent<PlayerController>();
            Destroy(gameObject);
            for(int i = 0; i < spawnNumber; i++)
            {
                Instantiate(p.gameObject);
            }
        }
    }
}
