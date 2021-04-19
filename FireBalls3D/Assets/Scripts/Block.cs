using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _breakParticles;
    public event UnityAction<Block> BulletHit;
    
    public void Break()
    {
        BulletHit?.Invoke(this);
        Instantiate(_breakParticles, transform.position, _breakParticles.transform.rotation);
        Destroy(gameObject);
    }
}
