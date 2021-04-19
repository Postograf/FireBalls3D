using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private TMP_Text _blockCount;
    private List<Block> _blocks = new List<Block>();
    
    private void Start()
    {
        _blocks = GetComponent<TowerBuilder>().Build();
        _blockCount.text = _blocks.Count.ToString();

        foreach (var block in _blocks)
        {
            block.BulletHit += OnBulletHit;
        }
    }
    
    private void OnBulletHit(Block block)
    {
        block.BulletHit -= OnBulletHit;
        _blocks.Remove(block);
        _blockCount.text = _blocks.Count.ToString();

        var offset = new Vector3(0, block.transform.localScale.y, 0);
        foreach (var b in _blocks)
        {
            b.transform.position -= offset;
        }
    }
}
