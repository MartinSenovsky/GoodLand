using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

    public float moveDistance;
    public float currentDistance;
    public int numFramesToClose;

    private int state = 0;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float moveDist;
    private float time;

	// Use this for initialization
	void Start () {
        startPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z); 
        endPosition = new Vector3(transform.position.x, transform.position.y - moveDistance, transform.position.z);
        time = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (state == 1)
        {
            // opening
            time++;
            transform.position = Vector3.Lerp(startPosition, endPosition, time / numFramesToClose);
        }
        else if (state == -1)
        {
            // close
            time--;
            transform.position = Vector3.Lerp(startPosition, endPosition, numFramesToClose / time);
        }
	}


    public void Open()
    {
        time = 0;
        state = 1;
    }

    public void Close()
    {
        time = numFramesToClose;
        state = -1;
    }
}
