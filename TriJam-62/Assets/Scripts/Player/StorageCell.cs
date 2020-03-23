using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCell : BaseCell {
	public float energyCapAdd = 50f;

	public override void OnBuild() {
		Player.instance.maxEnergy += energyCapAdd;
	}

	public override void OnKill() {
		Player.instance.maxEnergy -= energyCapAdd;
	}

}
