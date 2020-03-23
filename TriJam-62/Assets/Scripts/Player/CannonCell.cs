using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCell : BaseCell {
	public GameObject cannon;
	public GameObject shootPos;
	public GameObject bulletPrefab;

	public float shootTime = 0.5f;
	public float t;

	Camera main;

	private void Start() {
		main = Camera.main;
	}

	void Update() {
		if (Player.instance.buildSelectionCurr != null || Player.instance.selectedCell != this) {
			t = shootTime;
			return;
		}

		Vector3 newPos = main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
		cannon.transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

		t -= Time.deltaTime;
		if (t <= 0 && Input.GetMouseButton(0)) {
			t = shootTime;
			Player.instance.shake.ShakeCamera(Vector3.right, Random.Range(0, 2) == 1);
			Instantiate(bulletPrefab, shootPos.transform.position, cannon.transform.rotation, Player.instance.transform);
		}
	}
}
