using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Warrior : MonoBehaviour
{
    [SerializeField] private int _maxHealth = 10;
    [SerializeField] protected float _movementSpeed = 3f;
    [SerializeField] protected float _runSpeed = 6f;
    [SerializeField] private int _points = 0;
    protected Rigidbody _rigidbody;
    protected Transform _target;
    protected UI _ui;
    protected bool _ground;
    protected int _currentHealth;
    

    protected virtual void Start()
    {
        _currentHealth = _maxHealth;
        _rigidbody = GetComponent<Rigidbody>();
        _target = GameObject.FindGameObjectWithTag("Player").transform;
        _ui = GameObject.FindGameObjectWithTag("UI").GetComponent<UI>();
    }


    public virtual void TakeDamage(int damage)
    {
        _currentHealth -= damage;

        if (_currentHealth <= 0)
        {
            Stats.Score += _points;
            _ui.UpdateScoreAndLevel();
            Destroy(gameObject);
        }
        print(_currentHealth);
    }


    protected abstract void Move();
}
