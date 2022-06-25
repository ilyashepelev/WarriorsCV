using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeEnemy : Archer
{
    [SerializeField] private float _distanceToPlayer = 5f;
    private float _timer;


    protected override void Move()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    }


    private void Update()
    {
        if (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.position) > _distanceToPlayer)
            {
                Move();
            }
            transform.LookAt(_target);
        }
        
        if (_timer <= 0)
        {
            Shoot();
            _timer = _reloadTime;
        }
        else
        {
            _timer -= Time.deltaTime;
        }
    }
}
