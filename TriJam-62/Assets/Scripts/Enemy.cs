using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public float maxHp = 100.0f;
	public float takeDmg = 10;
	public float currHp;

	public Slider hpSlider;

	public float speed = 7.5f;
	BaseCell currTarget = null;

	private void Awake() {
		maxHp = Random.Range(10, 50);
		currHp = maxHp;

		hpSlider.gameObject.SetActive(false);
		hpSlider.minValue = 0;
		hpSlider.maxValue = maxHp;
	}

	void Update() {
		if(currTarget == null && Player.instance.cells.Count != 0) {
			currTarget = Player.instance.cells.Random();
		}

		if(currTarget != null) {
			Vector3 newPos = currTarget.transform.position - transform.position;
			float angle = Mathf.Atan2(newPos.y, newPos.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));

			transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
		}

		hpSlider.transform.parent.localRotation = Quaternion.Euler(-transform.rotation.eulerAngles);
	}

	public void TakeDamage() {
		currHp -= takeDmg;
		if (currHp <= 0) {
			Destroy(gameObject);
		}

		hpSlider.value = currHp;
		hpSlider.gameObject.SetActive(true);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		if(collision.gameObject.tag == "Cell") {
			collision.gameObject.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
			Destroy(gameObject);
		}
	}
}
