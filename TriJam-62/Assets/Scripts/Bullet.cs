using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public float speed = 5.0f;

	private void Awake() {
		LeanTween.delayedCall(gameObject, 5.0f, () => {
			Destroy(gameObject);
		});
	}

	private void OnDestroy() {
		LeanTween.cancel(gameObject, false);
	}

	private void Update() {
		transform.Translate(transform.up * speed * Time.deltaTime, Space.World);
	}

	private void OnCollisionEnter2D(Collision2D collision) {
		collision.gameObject.SendMessage("TakeDamage", SendMessageOptions.DontRequireReceiver);
		Destroy(gameObject);
	}
}
