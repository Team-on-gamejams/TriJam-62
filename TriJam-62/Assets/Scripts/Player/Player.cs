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

	public TextMeshProUGUI scoreText;
	public float score;

	public bool isPlaying = false;
	public GameObject tutorial;
	public GameObject endGame;

	public float currEnergy;
	public float maxEnergy;
	public Action onAddEnergy;

	public List<BaseCell> cells;
	public BaseCell selectedCell;

	private void Awake() {
		instance = this;
	}

	private void Update() {
		AddEnergy(Time.deltaTime);

		if (isPlaying) {
			scoreText.text = "Score: " + (score += Time.deltaTime).ToString("0");
		}
	}

	public void AddEnergy(float e) {
		currEnergy += e;
		if (currEnergy > maxEnergy)
			currEnergy = maxEnergy;
		energyText.text = $"Energy: {(int)currEnergy}/{maxEnergy}";
		onAddEnergy?.Invoke();
	}
}
