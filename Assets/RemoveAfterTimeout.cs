using UnityEngine;
using System.Collections;

public class RemoveAfterTimeout : MonoBehaviour {

    // frames
    public int timeout = 90;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timeout--;
        if (timeout <= 0)
        {
            Destroy(gameObject);
        }
	}
}
