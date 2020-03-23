using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildSelection : MonoBehaviour {
	public float price;
	public GameObject buildPrefab;

	public GameObject canBuild;
	public GameObject cantBuild;

	Camera main;

	private void Awake() {
		main = Camera.main;
	}

	void Update() {
		Vector3 newPos = main.ScreenToWorldPoint(Input.mousePosition);
		newPos.z = 0;
		transform.position = newPos;

		Ray ray = main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit, 100, LayerMask.GetMask("Default"))) {
			canBuild.SetActive(false);
			cantBuild.SetActive(true);
		}
		else {
			canBuild.SetActive(true);
			cantBuild.SetActive(false);

			if (Input.GetMouseButtonDown(0)) {
				Instantiate(buildPrefab, transform.position, Quaternion.identity, Player.instance.transform);
				Destroy(gameObject);
				Player.instance.buildSelectionCurr = null;
			}
		}

		
		if (Input.GetMouseButtonDown(1)) {
			Player.instance.AddEnergy(price);
			Destroy(gameObject);
			Player.instance.buildSelectionCurr = null;
		}
	}
}
