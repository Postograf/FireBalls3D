using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    private List<Block> _blocks = new List<Block>();
    
    private void Start()
    {
        _blocks = GetComponent<TowerBuilder>().Build();
    }
}
