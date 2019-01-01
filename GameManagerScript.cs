using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public bool gameOver = true;
    public GameObject player;
    public GameObject spawn;

    private UIManager _uiManager;
    


    
    public void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update ()
    {
	 if(gameOver == true)
        {
            if(Input.GetButton("Jump"))
            {
                Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
                Instantiate(spawn, new Vector3( 0 , 0 , 0),Quaternion.identity);
                gameOver = false;
                _uiManager.HideStartScreen();
            }
        }
        
	}
}
