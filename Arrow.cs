using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField] protected int _damage = 5;
    [SerializeField] protected float _speed = 3f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Warrior>() != null)
        {
            other.gameObject.GetComponent<Warrior>().TakeDamage(_damage);
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
