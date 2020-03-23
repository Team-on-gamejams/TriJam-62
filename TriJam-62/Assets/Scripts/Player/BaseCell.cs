using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCell : MonoBehaviour {
	public float needEnergyForBuild = 20.0f;
	public float maxHp = 100.0f;
	public float currHp;

	public GameObject selection;

	private void Awake() {
		currHp = maxHp;
		selection.SetActive(false);

		OnBuild();
	}

	public virtual void OnBuild() {
		Player.instance.cells.Add(this);
	}

	public virtual void OnKill() {
		Player.instance.cells.Remove(this);
	}

	public virtual void Select() {
		selection.SetActive(true);
		Player.instance.camera.Follow = this.gameObject.transform;
		Player.instance.camera.LookAt = this.gameObject.transform;
	}

	public virtual void Unselect() {
		selection.SetActive(false);
	}

	void OnMouseDown() {
		Player.instance.selectedCell?.Unselect();
		Player.instance.selectedCell = this;
		Select();
	}
}
