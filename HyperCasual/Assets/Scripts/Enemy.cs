using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private Transform _destroyPosition;
    private float _angle, _speed;

    private void Start()
    {
        _angle = Random.Range(-90, 90);
        _speed = Random.Range(1f, 1.4f);
        //StartCoroutine(IncreaseSpeed());
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _destroyPosition.transform.position, _speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, _angle) * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Destroy")
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator IncreaseSpeed()
    {
        yield return new WaitForSeconds(30f);
        _speed = Random.Range(1f, 3f);
    }
}
