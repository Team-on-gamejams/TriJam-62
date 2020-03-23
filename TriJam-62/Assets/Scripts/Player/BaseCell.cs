using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseCell : MonoBehaviour {
	public float needEnergyForBuild = 20.0f;
	public float maxHp = 100.0f;
	public float takeDmg = 30;
	public float currHp;

	public GameObject selection;
	public Slider hpSlider;

	private void Awake() {
		currHp = maxHp;
		selection.SetActive(false);
		hpSlider.gameObject.SetActive(false);
		hpSlider.minValue = 0;
		hpSlider.maxValue = maxHp;

		OnBuild();
	}

	private void OnDestroy() {
		OnKill();
	}

	public virtual void OnBuild() {
		Player.instance.cells.Add(this);
	}

	public virtual void OnKill() {
		Player.instance.cells.Remove(this);
	}

	public virtual void Select() {
		Player.instance.isPlaying = true;
		selection.SetActive(true);
		Player.instance.camera.Follow = this.gameObject.transform;
		Player.instance.camera.LookAt = this.gameObject.transform;
	}

	public virtual void Unselect() {
		selection.SetActive(false);
	}

	public void TakeDamage() {
		currHp -= takeDmg;
		if(currHp <= 0) {
			Destroy(gameObject);
		}

		hpSlider.value = currHp;
		hpSlider.gameObject.SetActive(true);
	}

	void OnMouseDown() {
		if(Player.instance.selectedCell != null)
			Player.instance.selectedCell.Unselect();
		Player.instance.selectedCell = this;
		Select();
	}
}
