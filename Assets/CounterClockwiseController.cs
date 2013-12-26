using UnityEngine;
using System.Collections;

public class CounterClockwiseController : MonoBehaviour {

    public int amount = 200;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController p = collider.gameObject.GetComponent<PlayerController>();
            p.SetRotation(amount);
            Destroy(gameObject);
        }
    }
}
