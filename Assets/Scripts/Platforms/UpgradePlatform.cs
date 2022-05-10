using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradePlatform : MonoBehaviour {
    [SerializeField] private UpgradeCanvas _upgradeCanvas;

    void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<Player>()) {
            _upgradeCanvas.OnEnter();
        }
    }
    
    void OnTriggerExit(Collider collider) {
        if (collider.GetComponent<Player>()) {
            _upgradeCanvas.OnExit();
        }
    }
}
