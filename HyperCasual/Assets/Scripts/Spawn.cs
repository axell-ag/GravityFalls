using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPosition;
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }
    void Update()
    {
        _spawnPosition.position = new Vector2(-3.63f, Random.Range(-1f, 1f));
    }
    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(1.3f);
        _enemy.SetActive(true);
        Instantiate(_enemy, _spawnPosition.position, Quaternion.identity);
        Start();
    }
}
