using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Characteristics {
    public UpgradeSystem _upgradeSystem;
    public float GetSawDamage() {
        return _upgradeSystem.GetSawDamage();
    }
    public int GetCapacity() {
        return _upgradeSystem.GetCapacity();
    }
    public float GetSpeedMovement() {
        return _upgradeSystem.GetSpeedMovement();
    }
    public float GetSpeedRotation() {
        return _upgradeSystem.GetSpeedRotation();
    }
    public List<LogAnimation> Logs;
}
