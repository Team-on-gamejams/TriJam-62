using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using TMPro;

public class Player : MonoBehaviour {
	public static Player instance;

	public CinemachineVirtualCamera camera;
	public GeneralCameraShake shake;
	public TextMeshProUGUI energyText;
	public BuildSelection buildSelectionPrefab;
	public BuildSelection buildSelectionCurr;

	public float currEnergy;
	public float maxEnergy;
	public Action onAddEnergy;

	public List<BaseCell> cells;
	public BaseCell selectedCell;

	private void Awake() {
		instance = this;
	}

	public void AddEnergy(float e) {
		currEnergy += e;
		if (currEnergy > maxEnergy)
			currEnergy = maxEnergy;
		energyText.text = $"Energy: {currEnergy}/{maxEnergy}";
		onAddEnergy?.Invoke();
	}
}
