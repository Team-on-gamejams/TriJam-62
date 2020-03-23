using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject[] enemyPrefabs;
	public GameObject[] spawnPoints;

	public float spawnTime = 5.0f;
	public float spawnTimeAdd = 0.2f;

	float t;

	private void Awake() {
		t = spawnTime;
	}

	private void Update() {
		if (!Player.instance.isPlaying)
			return;

		t -= Time.deltaTime;
		if (t <= 0) {
			t = spawnTime;
			if(spawnTime >= 1.0f)
				spawnTime -= spawnTimeAdd;
			Instantiate(enemyPrefabs[0], spawnPoints.Random().transform.position, Quaternion.identity, transform);
		}
	}
}
