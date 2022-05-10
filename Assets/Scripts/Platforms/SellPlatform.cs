using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellPlatform : MonoBehaviour {
    [SerializeField] private Player _player;
    [SerializeField] private UpgradeSystem _upgradeSystem;
    [SerializeField] private float _deltaTime;
    private float _nextTime = 0.0f;
    private bool _selling = false;

    void Update() {
        if (_selling && Time.time >= _nextTime && _player._characteristics.Logs.Count > 0) {
            var lst = _player._characteristics.Logs;
            lst.Last().FloatToPile();
            _upgradeSystem.CoinAmount += lst.Last()._cost;
            lst.RemoveAt(lst.Count - 1);
            _nextTime = Time.time + _deltaTime;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<Player>()) {
            _selling = true;
        }
    }
    
    void OnTriggerExit(Collider collider) {
        if (collider.GetComponent<Player>()) {
            _selling = false;
        }
    }
}
