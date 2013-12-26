using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {

    public KeyCode flyKeyPlayer0 = KeyCode.A;
    public KeyCode flyKeyPlayer1 = KeyCode.S;
    public KeyCode flyKeyPlayer2 = KeyCode.D;
    public KeyCode flyKeyPlayer3 = KeyCode.F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(flyKeyPlayer0))
        {
            PlayerController.FlyUp(0);
        }

        if (Input.GetKey(flyKeyPlayer1))
        {
            PlayerController.FlyUp(1);
        }

        if (Input.GetKey(flyKeyPlayer2))
        {
            PlayerController.FlyUp(2);
        }

        if (Input.GetKey(flyKeyPlayer3))
        {
            PlayerController.FlyUp(3);
        }



        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            Application.Quit(); 
        }
	}
}
