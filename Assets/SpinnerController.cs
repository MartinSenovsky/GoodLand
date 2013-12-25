using UnityEngine;
using System.Collections;

public class SpinnerController : MonoBehaviour {

    public float speed;
    public 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D body = GetComponent<Rigidbody2D>();
        body.angularVelocity = speed;
	}
}
