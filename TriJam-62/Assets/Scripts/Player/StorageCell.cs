using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageCell : BaseCell {
	public float energyCapAdd = 50f;

	public override void OnBuild() {
		base.OnBuild();
		Player.instance.maxEnergy += energyCapAdd;
		Player.instance.AddEnergy(0);
	}

	public override void OnKill() {
		base.OnKill();
		Player.instance.maxEnergy -= energyCapAdd;
		Player.instance.AddEnergy(0);
	}

}
