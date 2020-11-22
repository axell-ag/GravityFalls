using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _point1, _point2, _effect;
    [SerializeField] private Text _сounterText;
    private float _speed = 1.5f;
    private float _count = 0f;
    private bool _check = true;

    private void Update()
    {
        _сounterText.text = _count.ToString();
        TouchScreen();
        MovePlayer();
        transform.Rotate(new Vector3(0, 0, 70) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _effect.SetActive(true);
            //gameObject.SetActive(false);
            StartCoroutine(PlayerDies());
        }
    }
    private void MovePlayer()
    {
        if (_check)
        {
            Move(_point1, _point2, - 1.917f);
        }
        else if (!_check)
        {
            Move(_point2, _point1, 1.37f);
        }

        void Move (GameObject point1, GameObject point2, float position)
        {
            transform.position = Vector2.MoveTowards(transform.position, point1.transform.position, _speed * Time.deltaTime);
            if (transform.position == point1.transform.position)
            {
                _count++;
                _check = !_check;
                point1.SetActive(false);
                point2.transform.position = new Vector2(Random.Range(-2f, 0.20f), position);
                point2.SetActive(true);
            }
        }
    }

    private void TouchScreen()
    {
        if (Input.GetMouseButtonDown(0))
       /* if (Input.touchCount > 0)*/
        {
            _check = !_check;
        }
    }

    IEnumerator PlayerDies()
    {
        yield return new WaitForSeconds(.5f);
        gameObject.SetActive(false);
    }
}
