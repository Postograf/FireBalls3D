using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TowerBuilder))]
public class Tower : MonoBehaviour
{
    [SerializeField] private TMP_Text _blockCount;
    private List<Block> _blocks = new List<Block>();
    public event UnityAction Break;
    
    private void Start()
    {
        Break += FindObjectOfType<FinishDetector>().OnTowerBreak;
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

        if (_blocks.Count == 0)
            Break?.Invoke();

        var offset = new Vector3(0, block.transform.localScale.y, 0);
        foreach (var b in _blocks)
        {
            b.transform.position -= offset;
        }
    }
}
