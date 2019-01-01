using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {


    [SerializeField]
   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
		
	}

    public void DeleteExplosion()
    {
        Destroy(this.gameObject);
    }
}
