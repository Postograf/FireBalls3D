using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private ParticleSystem _breakParticles;
    public event UnityAction<Block> BulletHit;
    
    private MeshRenderer _meshRenderer;
    
    private void Awake()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Break()
    {
        BulletHit?.Invoke(this);
        Instantiate(_breakParticles, transform.position, _breakParticles.transform.rotation);
        Destroy(gameObject);
    }

    public void SetColor(Color color)
    {
        _meshRenderer.material.color = color;
    }
}
