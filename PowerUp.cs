using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    private float _speed = 3.0f;
    [SerializeField]
    private int _powerUpID;
    [SerializeField]
    private AudioClip _audioclip;

    

    void Start ()
    {

        
    }
	
	
	void Update ()
    {
       
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -6)
        {
            Destroy(this.gameObject);
        }
	}
    public void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.tag == "Player")
        {

            AudioSource.PlayClipAtPoint(_audioclip, Camera.main.transform.position,1f);
            if (_powerUpID == 0)
            {
                other.GetComponent<Player>().TripleShotOn();
            }
            else if(_powerUpID == 1)
            {
                other.GetComponent<Player>().SpeedPowerUp();
            }
            else if (_powerUpID == 2)
            {
                other.GetComponent<Player>().ShieldPowerUp();
            }
            
        }

        Destroy(this.gameObject);
        

    }

   
    


}
