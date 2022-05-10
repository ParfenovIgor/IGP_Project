using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TreeAnimation : MonoBehaviour {
    [SerializeField] private GameObject _logPrefab;
    [SerializeField] private float _health = 1.0f;
    [SerializeField] private int _cost = 1;
    [SerializeField] private Vector3 _initPosition, _initScale;
    private Player _player;
    private bool _onCollision;

    void Start() {
        transform.position += _initPosition;
        transform.localScale = Vector3.Scale(transform.localScale, _initScale);
    }

    void Update() {
        if (_onCollision) {
            _health -= _player._characteristics.GetSawDamage() * Time.deltaTime;
            if (_health <= 0) {
                Vector3 position = transform.position;
                position.y = 0.0f;
                GameObject log = Instantiate(_logPrefab, position, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                var logAnimation = log.GetComponent<LogAnimation>();
                logAnimation._cost = _cost;
                DOTween.Kill(this);
                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision other) {
        var player = other.gameObject.GetComponent<Player>();
        if (player) {
            _player = player;
            _onCollision = true;
        }
        transform.DOShakePosition(1.0f, 0.2f, 100, 0, false).SetId(this);
    }

    void OnCollisionExit(Collision other) {
        if (other.gameObject.GetComponent<Player>()) {
            _onCollision = false;
        }
    }
}
