using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroids : MonoBehaviour
{
    [SerializeField] List<GameObject> AsteroidTypes;
    [SerializeField] int TimeBetweenWaveWave;

    [SerializeField] int MinPerWave;
    [SerializeField] int MaxPerWave;

    int Amount;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnWave", 0, TimeBetweenWaveWave);
    }

    void SpawnWave()
    {
        Amount = Random.Range(MinPerWave, MaxPerWave);

        for (int i = 0; i < Amount; i++)
        {
            SpawnAsteroid();
        }
    }

    void SpawnAsteroid()
    {
        GameObject SpawnedAsteroid = Instantiate(AsteroidTypes[Random.Range(0, AsteroidTypes.Count)]);
        SpawnedAsteroid.GetComponent<Rigidbody>().AddTorque(new Vector3(Random.Range(-50, 50), Random.Range(-50, 50), Random.Range(-50, 50)));
        Debug.Log(SpawnedAsteroid.gameObject.name);
        SpawnedAsteroid.transform.position = transform.position;
        SpawnedAsteroid.transform.position += new Vector3(Random.Range(-40, 40), Random.Range(-10, 10), 0);
    }
}
