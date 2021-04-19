using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField] private float _bounceForce = 100f;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<Obstacle>(out Obstacle obstacle))
        {
            Bounce();
        }
        else if (other.TryGetComponent<Block>(out Block block))
        {
            block.Break();
            Destroy(gameObject);
        }
    }

    private void Bounce()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        var cameraView = (Camera.main.transform.position - transform.position).normalized;
        rigidbody.AddForce(cameraView * _bounceForce, ForceMode.Impulse);
    }
}
