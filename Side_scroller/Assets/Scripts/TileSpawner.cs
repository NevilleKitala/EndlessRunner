using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileSpawner : MonoBehaviour {

	public GameObject [] tilePrefabs;

	private float spawn = 0.0f;
	private float tileLength = 200.0f;

	private int lastPrefabIndex = 0;
	private int amttilesScreen = 2;
	private float safeZone = 230.0f;

	private Transform playerTransform;

	private List<GameObject> activetiles;
	// Use this for initialization

	void Start () {
		activetiles = new List<GameObject> ();
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform;

		for(int i = 0; i < amttilesScreen; i++){
			SpawnTile(0);
		}
	}
	
	// Update is called once per frame
	void Update() {
		if(playerTransform != null){
			if (playerTransform.position.x - safeZone > (spawn - amttilesScreen * tileLength)) {
				SpawnTile ();
				DeleteTile ();
			}
		}
}
	private void SpawnTile(int prefabIndex = -1){
		GameObject go;
		if (prefabIndex == -1)
			go = Instantiate (tilePrefabs [RandomPrefabIindex ()]) as GameObject;
		else
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.right * spawn;
		spawn += tileLength;
		activetiles.Add (go);
	}
	private void DeleteTile(){
		Destroy (activetiles [0]);
		activetiles.RemoveAt(0);
	}

	private int RandomPrefabIindex(){
		if (tilePrefabs.Length <= 1)
			return 0;

		int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex) {
			randomIndex = Random.Range (0, tilePrefabs.Length);
		}
		lastPrefabIndex = randomIndex;
		return randomIndex;
	}
}
