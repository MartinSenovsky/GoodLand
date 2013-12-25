using UnityEngine;
using System.Collections;

public class GrowController : MonoBehaviour {

    public float amount = 0.5f;

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
            p.AddSize(amount);
            Destroy(gameObject);
        }
    }
}
