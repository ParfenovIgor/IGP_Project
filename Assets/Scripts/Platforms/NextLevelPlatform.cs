using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelPlatform : MonoBehaviour {
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Canvas _canvas;
    [SerializeField] private Material _materialEnabled;
    [SerializeField] private Material _materialDisabled;
    [SerializeField] private Button _buttonNextLevel;

    private MeshRenderer _meshRenderer;

    void Start() {
        _meshRenderer = GetComponent<MeshRenderer>();
        
        _buttonNextLevel.onClick.AddListener(ButtonNextLevelClick);
    }

    void Update() {
        if (_levelGenerator.NextLevelEnabled()) {
            _meshRenderer.material = _materialEnabled;
        }
        else {
            _meshRenderer.material = _materialDisabled;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.GetComponent<Player>()) {
            if (_levelGenerator.NextLevelEnabled()) {
                _canvas.enabled = true;
            }
        }
    }
    
    void OnTriggerExit(Collider collider) {
        if (collider.GetComponent<Player>()) {
            _canvas.enabled = false;
        }
    }

    void ButtonNextLevelClick() {
        _levelGenerator.NextLevel();
        _canvas.enabled = false;
    }
}
