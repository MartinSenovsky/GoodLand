using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch t = Input.touches[i];

            if (t.position.x < Screen.width / 2 && t.position.y < Screen.height / 2)
            {
                // top left
                Debug.Log("top left");
                PlayerController.FlyUp(0);
            }
            else if (t.position.x < Screen.width / 2 && t.position.y > Screen.height / 2)
            {
                // bottom left
                Debug.Log("bottom left");
                PlayerController.FlyUp(1);
            }
            else if (t.position.x > Screen.width / 2 && t.position.y < Screen.height / 2)
            {
                // top right
                Debug.Log("top right");
                PlayerController.FlyUp(2);
            }
            else if (t.position.x > Screen.width / 2 && t.position.y > Screen.height / 2)
            {
                // bottom right
                Debug.Log("bottom right");
            }
        }
	}
}
