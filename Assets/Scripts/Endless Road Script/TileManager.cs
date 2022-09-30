using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{




    [SerializeField] private ObjectPool objectPool = null;

    public float zSpawn = 0;
    public float tileLength = 30;
    public int numberOfTiles = 5;





    private List<GameObject> activeTiles = new List<GameObject>();
    public Transform playerTransform;

    public float spawnDistance = 35;


    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0)
                SpawnTile(0);
            else { 
                SpawnTile(Random.Range(0, objectPool.pools.Length));
            }
        }
    }


    private void Update()
    {
        if (playerTransform.position.z - spawnDistance > zSpawn - (numberOfTiles * tileLength))    //karakter en son geçtiði tile'dan 35 kadar uzaklaþtýktan sonra yeni tile üretilecek
        {
            SpawnTile(Random.Range(0, objectPool.pools.Length));
            DeleteTile();
        }
    }


    public void SpawnTile(int tileIndex)
    {


        var go = objectPool.GetPooledObject(tileIndex);
        go.transform.position = transform.forward * zSpawn;

        activeTiles.Add(go);
        zSpawn += tileLength;
    }
    private void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }




}
