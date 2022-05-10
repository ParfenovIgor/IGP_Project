using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeCanvas : MonoBehaviour {
    [SerializeField] private UpgradeSystem _upgradeSystem;

    [SerializeField] private Button _upgradeSawButton;
    [SerializeField] private Text _upgradeSawText;
    [SerializeField] private Image _upgradeSawBar;

    [SerializeField] private Button _upgradeCapacityButton;
    [SerializeField] private Text _upgradeCapacityText;
    [SerializeField] private Image _upgradeCapacityBar;

    [SerializeField] private Button _upgradeSpeedButton;
    [SerializeField] private Text _upgradeSpeedText;
    [SerializeField] private Image _upgradeSpeedBar;
    
    private Canvas _canvas;

    void Start() {
        _canvas = GetComponent<Canvas>();

        _upgradeSawButton.onClick.AddListener(ButtonUpgradeSawClick);
        _upgradeCapacityButton.onClick.AddListener(ButtonUpgradeCapacityClick);
        _upgradeSpeedButton.onClick.AddListener(ButtonUpgradeSpeedClick);
    }

    void Update() {
        _upgradeSawBar.fillAmount = (float)_upgradeSystem._upgradeSaw.Level / _upgradeSystem._upgradeSaw.MaxLevel();
        _upgradeCapacityBar.fillAmount = (float)_upgradeSystem._upgradeCapacity.Level / _upgradeSystem._upgradeCapacity.MaxLevel();
        _upgradeSpeedBar.fillAmount = (float)_upgradeSystem._upgradeSpeed.Level / _upgradeSystem._upgradeSpeed.MaxLevel();

        _upgradeSawText.text = _upgradeSystem._upgradeSaw.GetCostText();
        _upgradeCapacityText.text = _upgradeSystem._upgradeCapacity.GetCostText();
        _upgradeSpeedText.text = _upgradeSystem._upgradeSpeed.GetCostText();
    }

    private void ButtonUpgradeSawClick() {
        _upgradeSystem.UpgradeSaw();
    }

    private void ButtonUpgradeCapacityClick() {
        _upgradeSystem.UpgradeCapacity();
    }

    private void ButtonUpgradeSpeedClick() {
        _upgradeSystem.UpgradeSpeed();
    }

    public void OnEnter() {
        _canvas.enabled = true;
    }

    public void OnExit() {
        _canvas.enabled = false;
    }
}
