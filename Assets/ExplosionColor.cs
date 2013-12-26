using UnityEngine;
using System.Collections;


public class ExplosionColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    public void SetColor(Color color)
    {
        ParticleSystem[] systems = GetComponentsInChildren<ParticleSystem>();
        for(int i = 0; i < systems.Length; i++)
        {
            systems[i].startColor = color;
        }
    }
}
