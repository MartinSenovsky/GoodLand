using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {

    public DoorController doors;
    public bool open;

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
            Destroy(gameObject);
            if (doors)
            {
                if (open)
                {
                    doors.Open();
                }
                else
                {
                    doors.Close();
                }
            }
        }
    }
}
