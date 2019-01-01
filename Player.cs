using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private GameObject _shield;
    [SerializeField]
    private GameObject[] _engines;
    [SerializeField]
    private GameObject[] _turns;


    private float _fireRate = 0.25f;
    private float _nextFire = 0.0f;
    public float speed = 5.0f;
    public bool tripleShot = false;
    public bool speedPowerUp = false;
    public bool shieldPowerUp = false;
    public int health = 3;
    public int shieldHealth = 0;

    private float _hitCount = 0;

    private UIManager _uiManager;
    private GameManagerScript _gameManager;

	void Start ()
    {
        transform.position = new Vector3(0, 0, 0);

        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();

        if( _uiManager != null)
        {
            _uiManager.UpdateLives(health);
        }

        _gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerScript>();

        _hitCount = 0;
    }
	
	void Update ()
    {
        Movement();
        LaserFire();
     

    }

    void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * Time.deltaTime * speed * moveHorizontal);
        transform.Translate(Vector3.up * speed * moveVertical * Time.deltaTime);


        if(Input.GetKeyDown("a"))
        {
            _turns[0].SetActive(true);
        }
       else if (Input.GetKeyUp("a"))
        {
            _turns[0].SetActive(false);
        }



        if (Input.GetKeyDown("d"))
        {
            _turns[1].SetActive(true);
        }

        if (Input.GetKeyUp("d"))
        {
            _turns[1].SetActive(false);
        }


        if (transform.position.y > 3.50f)
        {
            transform.position = new Vector3(transform.position.x, 3.50f, 0);
        }
        else if (transform.position.y < -3.50f)
        {
            transform.position = new Vector3(transform.position.x, -3.50f, 0);
        }

        if (transform.position.x > 9)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);
        }

        else if (transform.position.x < -9)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }
        
    }

    public void Damage()
    {
        

       
        shieldHealth--;
       
        if (shieldHealth == 0 )
        {
            
            if (shieldPowerUp)
            {
                
                var shield = GameObject.Find("Shield");
                shield.SetActive(false);

                shieldPowerUp = false;
               
               
            }

            
        }
        if (shieldHealth < 0)
        {
            health--;

            _uiManager.UpdateLives(health);
            _hitCount++;

            if (_hitCount > 0)
            {
                _engines[Random.Range(0, 2)].SetActive(true);
            }
        }


        

        if (health < 1)
        {
            PlayerExplosion();
            _gameManager.gameOver = true;
            _uiManager.ShowStartScreen();
            Destroy(this.gameObject);
        }

    }

    void LaserFire()
    {
        if (Input.GetButtonDown("Jump") && Time.time > _nextFire || Input.GetButtonDown("Fire1") && Time.time > _nextFire)
        {
            if (tripleShot)
            {
                _nextFire = Time.time + _fireRate;
                Instantiate(_tripleShotPrefab, transform.position + new Vector3(0.0f, 0.55f, 0.0f), Quaternion.identity);
            }
            else
            {
                _nextFire = Time.time + _fireRate;
                Instantiate(_laserPrefab, transform.position + new Vector3(0.0f, 0.92f, 0.0f), Quaternion.identity);
            }
        }
    }

    public void TripleShotOn()
    {
        tripleShot = true;
        StartCoroutine(TripleShotOff());

    }
    public IEnumerator TripleShotOff()
    {
        yield return new WaitForSeconds(5.0f);
        tripleShot = false;


    }
    public void SpeedPowerUp()
    {
        speedPowerUp = true;
        speed = speed * 2;
        StartCoroutine(SpeedPowerUpOff());
       

    }
    public IEnumerator SpeedPowerUpOff()
    {
        yield return new WaitForSeconds(10.0f);
        speedPowerUp = false;
        speed = speed / 2;
    }

    public void ShieldPowerUp()
    {
        shieldPowerUp = true;
        shieldHealth = 0;
        shieldHealth = shieldHealth + 3;
        Shield();
        //StartCoroutine(ShieldPowerUpOff());

    }
    public IEnumerator ShieldPowerUpOff()
    {
        yield return new WaitForSeconds(5.0f);
        shieldPowerUp = false;
    }

        public void PlayerExplosion()
    {
        Instantiate(_explosion, transform.position, Quaternion.identity);
    }
    public void Shield()
    {
       var shield = Instantiate(_shield, gameObject.transform.position , Quaternion.identity);
        shield.transform.parent = gameObject.transform;

        shield.name = "Shield";
    }
    
}


