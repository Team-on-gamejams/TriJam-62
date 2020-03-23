using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProduceCell : BaseCell {
	public float energyPerTick = 5.0f;
	public float tick = 1.0f;

	float currTime;

	private void Update() {
		currTime += Time.deltaTime;

		if(currTime >= tick) {
			currTime -= tick;
			Player.instance.AddEnergy(energyPerTick);
		}
	}
}
