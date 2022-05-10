using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {
    [SerializeField] private UpgradeSystem _upgradeSystem;
    [SerializeField] private Player _player;
    [SerializeField] private LevelGenerator _levelGenerator;

    [SerializeField] private Text _textCoinAmount;

    [SerializeField] private Text _textLogAmount;
    [SerializeField] private Image _logBar;

    [SerializeField] private Text _textTreeAmount;
    [SerializeField] private Image _treeBar;
    [SerializeField] private Image _nextLevelIcon;

    void Update() {
        _textCoinAmount.text = _upgradeSystem.CoinAmount.ToString();

        _textLogAmount.text = _player._characteristics.Logs.Count.ToString() + "/" + _player._characteristics.GetCapacity();
        _logBar.fillAmount = (float)_player._characteristics.Logs.Count / _player._characteristics.GetCapacity();

        _textTreeAmount.text = (_levelGenerator._totalTrees -  _levelGenerator.GetNumberOfTrees()).ToString() + "/" + _levelGenerator._totalTrees;
        _treeBar.fillAmount = (float)(_levelGenerator._totalTrees -  _levelGenerator.GetNumberOfTrees()) / _levelGenerator._totalTrees;

        if (_levelGenerator.NextLevelEnabled()) {
            _nextLevelIcon.enabled = true;
        }
        else {
            _nextLevelIcon.enabled = false;
        }
    }
}
