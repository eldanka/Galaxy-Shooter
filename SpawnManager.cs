using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject[] _powerUps;


    void Start()
    {
        StartCoroutine(EnemySpawn());
        StartCoroutine(SpawnPowerUps0());
        
    }


    public IEnumerator EnemySpawn()
    {
        while (true)
        {
            
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-8.5f, 8.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }
    }
    public IEnumerator SpawnPowerUps0()
    {
        while (true)
        {
            int randomPowerUp = Random.Range(0, 3);
            Instantiate(_powerUps[randomPowerUp], new Vector3(Random.Range(-8.5f, 8.5f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);

        }


    }
}
