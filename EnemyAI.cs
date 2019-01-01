using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {



    [SerializeField]
    private GameObject _enemyExplosion;
    [SerializeField]
    private GameObject _enemyPrefab;
    public float enemySpeed = 3.0f;

    private UIManager _uIManager;
 
     
    void Start()
    {
        _uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyMovement();

    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            EnemyExplosion();
            Destroy(other.gameObject);
            _uIManager.UpdateScore();
            Destroy(this.gameObject);
           

        }


        if(other.tag == "Player")
        {

            other.GetComponent<Player>().Damage();
            EnemyExplosion();
            _uIManager.UpdateScore();
            Destroy(this.gameObject);




        }
    }  

       

    void enemyMovement()
        {
            gameObject.transform.Translate(Vector3.down * enemySpeed * Time.deltaTime);

            if (transform.position.y < -7)
            {
                float randomX = Random.Range(-8.5f, 8.5f);
                transform.position = new Vector3(randomX, 7);
            }
        }
    public void EnemyExplosion()
    {
        Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
    }

}
