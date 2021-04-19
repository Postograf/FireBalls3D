using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tank : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private float _shootForce;
    [SerializeField] private float _delayAfterShoot;
    
    private float _timeToShoot;
    
    private void Update()
    {   
        if(_timeToShoot > 0)
            _timeToShoot -= Time.deltaTime;
        
        if (Input.GetMouseButton(0) && _timeToShoot <= 0)
        {
            Shoot();
            Recoil();
            _timeToShoot = _delayAfterShoot;
        }
    }

    private void Shoot()
    {
        Instantiate(_bullet, _shootPoint.position, Quaternion.identity)
            .GetComponent<Rigidbody>()
            .AddForce(Vector3.back * _shootForce, ForceMode.Impulse);
    }

    private void Recoil()
    {
        transform
            .DOMoveZ(transform.position.z + 0.25f, _delayAfterShoot / 2)
            .SetLoops(2, LoopType.Yoyo);
    }
}
