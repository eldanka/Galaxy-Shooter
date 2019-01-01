using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

    private float _speed = 10.0f;

	void Start ()
    {
		
	}
	
	void Update ()
    {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        Destroy(this.gameObject, 2.0f);
    }
}
