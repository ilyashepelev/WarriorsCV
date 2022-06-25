using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Warrior
{
    [SerializeField] protected int _damage = 100;


    protected override void Move()
    {
        transform.Translate(Vector3.forward * _movementSpeed * Time.deltaTime);
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.GetComponent<Player>() != null)
        {
            collision.gameObject.GetComponent<Player>().TakeDamage(_damage);
        }
    }


    private void Update()
    {
        if(_target != null)
        {
            Move();
            transform.LookAt(_target);
        }
    }
}
