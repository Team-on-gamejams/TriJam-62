using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public float maxHp = 100.0f;
	public float takeDmg = 10;
	public float currHp;

	public GameObject selection;

	private void Awake() {
		maxHp = Random.Range(10, 111);
		currHp = maxHp;
	}

	void Update() {

	}

	public void TakeDamage() {
		currHp -= takeDmg;
		if (currHp <= 0) {
			Destroy(gameObject);
		}
	}
}
