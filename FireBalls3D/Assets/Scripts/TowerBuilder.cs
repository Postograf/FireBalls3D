using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private int _blockCount;
    
    public List<Block> Build()
    {
        var currentBuildPoint = transform.position;
        var blocks = new List<Block>();
        
        for (int i = 0; i < _blockCount; i++)
        {
            UpdateBuildPoint(ref currentBuildPoint);
            blocks.Add(BuildBlock(currentBuildPoint));
        }

        return blocks;
    }

    private Block BuildBlock(Vector3 position)
    {
        return Instantiate(_blockPrefab, position, Quaternion.identity, transform);
    }

    private void UpdateBuildPoint(ref Vector3 currentBlock)
    {
        currentBlock.y += _blockPrefab.transform.localScale.y;
    }
}
