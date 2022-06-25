using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Archer : Warrior
{
    [SerializeField] private GameObject _arrow;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] protected float _reloadTime = 0.5f;


    protected void Shoot()
    {
        Instantiate(_arrow, _shootPoint.position, transform.rotation);
    }

}
