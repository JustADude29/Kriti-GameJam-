using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class birdSpawner : MonoBehaviour
{
    [SerializeField] private GameObject birdPrefab;
    public int _count;
    public float _minSpawnRate;
    public float _maxSpawnRate;
    public bool _stopSpawning;
    public Vector3 _spawnOffset;
    public GameObject Player;

    private float _spawnWait;
    void Start()
    {
        StartCoroutine(SpawnBird());
    }

    void Update()
    {
        //set spawn count based on the number of crops
        _count = (int)Random.Range(0, (int)Player.GetComponent<PlayerStats>().currProgression+1);
        
    }

    IEnumerator SpawnBird()
    {
        yield return new WaitForSeconds(_spawnWait);
        while (!_stopSpawning)
        {
            int temp = _count;
            _spawnWait = Random.Range(_minSpawnRate, _maxSpawnRate);
            for(int i=0;i <temp; i++) {
                Instantiate(birdPrefab, transform.position + new Vector3(Random.Range(-_spawnOffset.x-temp, _spawnOffset.x+temp), Random.Range(-_spawnOffset.y, _spawnOffset.y), Random.Range(-_spawnOffset.z-temp, _spawnOffset.z+temp)), Quaternion.identity, transform);
            }
            yield return new WaitForSeconds(_spawnWait);
        }
    }
}
