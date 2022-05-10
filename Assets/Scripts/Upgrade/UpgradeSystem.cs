using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour {
    public int CoinAmount = 0;
    [SerializeField] private Player _player;

    public UpgradeSaw _upgradeSaw;
    public UpgradeCapacity _upgradeCapacity;
    public UpgradeSpeed _upgradeSpeed;

    public void UpgradeSaw() {
        _upgradeSaw.Upgrade(ref CoinAmount);
    }

    public void UpgradeCapacity() {
        _upgradeCapacity.Upgrade(ref CoinAmount);
    }

    public void UpgradeSpeed() {
        _upgradeSpeed.Upgrade(ref CoinAmount);
    }

    public float GetSawDamage() {
        return _upgradeSaw.GetDamage();
    }

    public int GetCapacity() {
        return _upgradeCapacity.GetCapacity();
    }

    public float GetSpeedMovement() {
        return _upgradeSpeed.GetSpeedMovement();
    }

    public float GetSpeedRotation() {
        return _upgradeSpeed.GetSpeedRotation();
    }
}
