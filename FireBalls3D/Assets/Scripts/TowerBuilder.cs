using System.Collections.Generic;
using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;
    [SerializeField] private int _blockCount;

    private List<Block> _blocks = new List<Block>();
    
    // Start is called before the first frame update
    public List<Block> Build()
    {
        var currentBuildPoint = transform.position;
        
        for (int i = 0; i < _blockCount; i++)
        {
            UpdateBuildPoint(ref currentBuildPoint);
            _blocks.Add(BuildBlock(currentBuildPoint));
        }

        return _blocks;
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
