using UnityEngine;
using System.Collections;

public class EndController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Destroy(GetComponent<MeshFilter>());
        //Destroy(GetComponent<MeshRenderer>());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerController p = collider.gameObject.GetComponent<PlayerController>();
            p.FlyTo(transform.position.x - 2.439f, transform.position.y - 1.376f);
        }
    }
}
