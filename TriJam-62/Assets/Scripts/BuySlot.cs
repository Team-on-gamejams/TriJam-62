using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuySlot : MonoBehaviour {
	public float price;
	public GameObject prefab;
	public TextMeshProUGUI priceText;

	public GameObject movedPart;
	public GameObject closedPos;

	bool isOpen = true;

	private void Awake() {
		priceText.text = $"{price} E";
		Player.instance.onAddEnergy += OnAddEnergy;

		movedPart.transform.position = closedPos.transform.position;
		isOpen = false;
	}

	void OnAddEnergy() {
		if(Player.instance.currEnergy >= price) {
			Open();
		}
		else {
			Close();
		}
	}

	public void OnCLick() {
		if (Player.instance.buildSelectionCurr == null && Player.instance.currEnergy >= price) { 
			Player.instance.AddEnergy(-price);
			BuildSelection selection = Instantiate(Player.instance.buildSelectionPrefab, transform.position, Quaternion.identity, null).GetComponent< BuildSelection>();
			selection.price = price;
			selection.buildPrefab = prefab;
		}
	}

	void Open() {
		if (isOpen)
			return;
		isOpen = true;
		LeanTween.cancel(movedPart);
		LeanTween.moveLocalY(movedPart, 0, 1.0f)
			.setEase(LeanTweenType.easeOutBack);
	}

	void Close() {
		if (!isOpen)
			return;
		isOpen = false;
		LeanTween.cancel(movedPart);
		LeanTween.moveY(movedPart, closedPos.transform.position.y, 1.0f)
			.setEase(LeanTweenType.easeInBack);
	}
}
