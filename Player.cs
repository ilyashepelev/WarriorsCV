using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Archer
{
    [SerializeField] private float _jumpPower = 200f;
    private float _timer;


    public override void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _ui.UpdateHalthText(_currentHealth);
        if (_currentHealth <= 0)
        {
            Stats.ResetAllStats();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        print(_currentHealth);
    }


    protected override void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                transform.localPosition += transform.forward * _runSpeed * Time.deltaTime;
            }
            else
            {
                transform.localPosition += transform.forward * _movementSpeed * Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition -= transform.forward * _movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += transform.right * _movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition -= transform.right * _movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (_ground)
            {
                _rigidbody.AddForce(transform.up * _jumpPower);
            }
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            _ground = true;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _ground = false;
        }
    }


    private void Update()
    {
        Move();
        if(_timer <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                _timer = _reloadTime;
            }
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
