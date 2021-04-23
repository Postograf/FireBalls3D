using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private Color[] _blockColors;
    [SerializeField] private int _blockCount;
    
    public List<Block> Build()
    {
        var currentBuildPoint = transform.position;
        var blocks = new List<Block>();
        
        for (int i = 0; i < _blockCount; i++)
        {
            UpdateBuildPoint(ref currentBuildPoint);
            var block = BuildBlock(currentBuildPoint);
            
            if(_blockColors.Length > 0)
                block.SetColor(_blockColors[i % _blockColors.Length]);
            
            blocks.Add(block);
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
