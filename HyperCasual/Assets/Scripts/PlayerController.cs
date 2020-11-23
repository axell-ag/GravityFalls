using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _point1, _point2, _effect;
    [SerializeField] private Text _сounterText;
    [SerializeField] private Main _main;
    private float _speed = 1.5f;
    private float _count = 0f;
    private float _rotate = 70f;
    private bool _checkPoint = true;

    private void Start()
    {
        StartCoroutine(IncreaseSpeed(2f, 100f, 30f));
        StartCoroutine(IncreaseSpeed(2.5f, 130f, 60f));
    }
    private void Update()
    {
        TouchScreen();
        MovePlayer();
        _сounterText.text = _count.ToString();
        transform.Rotate(new Vector3(0, 0, _rotate) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            _effect.SetActive(true);
            StartCoroutine(PlayerDies());
        }
        if (collision.gameObject.tag == "Point")
        {
            ChangeCounter();
        }
    }
    private void MovePlayer()
    {
        switch(_checkPoint)
        {
            case true:
                Move(_point1, _point2, -1.917f);
                break;
            case false:
                Move(_point2, _point1, 1.37f);
                break;
        }

        void Move (GameObject point1, GameObject point2, float position)
        {
            transform.position = Vector2.MoveTowards(transform.position, point1.transform.position, _speed * Time.deltaTime);
            if (transform.position == point1.transform.position)
            {
                _checkPoint = !_checkPoint;
                point1.SetActive(false);
                point2.transform.position = new Vector2(Random.Range(-2f, 0.20f), position);
                point2.SetActive(true);
            }
        }
    }
    private void ChangeCounter()
    {
            _count++;
    }

    private void TouchScreen()
    {
        if (Input.GetMouseButtonDown(0))
       /* if (Input.touchCount > 0)*/
        {
            _checkPoint = !_checkPoint;
        }
    }

    private IEnumerator PlayerDies()
    {
        yield return new WaitForSeconds(.5f);
        _main.GetComponent<Main>().LoseScreen();
        gameObject.SetActive(false);
    }
    private IEnumerator IncreaseSpeed(float speed, float rotate, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _speed = speed;
        _rotate = rotate;
    }
}
