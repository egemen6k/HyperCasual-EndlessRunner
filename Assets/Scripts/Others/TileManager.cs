using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    [SerializeField]
    private Transform _playerTransform;
    [SerializeField]
    private GameObject _tile1;

    private float _zSpawn = 15f;
    private float _tileLength = 30f;
    private int _firstSpawnTilesCount = 5;
    private int _talesSize;

    private List<GameObject> _activeTiles;
    private ObjectPooler objectPooler;

    void Start()
    {
        objectPooler = ObjectPooler.Instance;
        _talesSize = objectPooler.poolDictionary.Count;
        _activeTiles = new List<GameObject>();

        for (int i = 0; i < _firstSpawnTilesCount; i++)
        {
            SpawnTile(Random.Range(0, _talesSize));
        }
    }

    void Update()
    {
        if (_playerTransform.position.z - 35f > _zSpawn - (_firstSpawnTilesCount * _tileLength))
        {
            SpawnTile(Random.Range(0, 6));
            Destroy(_tile1);
            DeleteTile();
        }
    }

    private void SpawnTile(int tileIndex)
    {
        GameObject pooled = objectPooler.SpawnFromPool(tileIndex.ToString(), transform.forward * _zSpawn, transform.rotation);
        _zSpawn += _tileLength;
        _activeTiles.Add(pooled);
    }

    private void DeleteTile()
    {
        _activeTiles[0].SetActive(false);
        _activeTiles.RemoveAt(0);
    }
}
