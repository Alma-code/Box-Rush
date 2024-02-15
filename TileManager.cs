using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour {
	public GameObject[] tilePrefabs;
	private Transform playerTransform;
	private float spawnZ = -90.22675f;
	private float tileLength = 154.4535f;
	private int amnTilesOnScreen = 6;
	public float  SafeZone = 50.0f;
	public Vector3 Offset;
	public List<GameObject> activeTiles;
	public int LastPrefabIndex = 0;
	
	// Use this for initialization
	void Start () {
	activeTiles = new List<GameObject>();
	playerTransform = GameObject.FindGameObjectWithTag("Player").transform;	
	 
	 for (int i = 0; i < amnTilesOnScreen; i++)
	 {
	 	 SpawnTile ();
	 }
	}
	
	// Update is called once per frame
	void Update () {
		if (playerTransform.position.z - SafeZone > (spawnZ - amnTilesOnScreen * tileLength))
		{
			SpawnTile();
			DeleteTile();
		}
	}

	void SpawnTile(int prefabIndex = -1)
	{
		GameObject go;
		go = Instantiate (tilePrefabs [RandomPrefabIndex()]) as GameObject;
		go.transform.SetParent(transform);
		go.transform.position = (Vector3.forward * spawnZ) + Offset;
		spawnZ += tileLength;
		activeTiles. Add(go);
	}
	public void DeleteTile()
	{
		Destroy (activeTiles[0]);
		activeTiles.RemoveAt(0); 
	}
	public int RandomPrefabIndex()
	{
		if (tilePrefabs.Length <=1)
			return 0;
		
		int randomIndex = LastPrefabIndex;
		while (randomIndex == LastPrefabIndex)
			{
			randomIndex = Random.Range (0, tilePrefabs.Length);
			}
			LastPrefabIndex = randomIndex;
			return randomIndex;

	}
}
