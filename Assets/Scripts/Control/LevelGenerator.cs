using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelInfo {
    public int[] TreeNumber;
}

public class LevelGenerator : MonoBehaviour {
    [SerializeField] private bool _resetGame;
    [SerializeField] private int _currentLevel;
    [SerializeField] private UpgradeSystem _upgradeSystem;
    [SerializeField] private GameObject[] _treePrefab;

    [SerializeField] private LevelInfo[] _levels;
    [System.NonSerialized] public int _totalTrees;

    [SerializeField] private float _leftBorder, _rightBorder, _forwardBorder, _backwardBorder;

    private List<GameObject> _trees = new List<GameObject>();

    void Start() {
        foreach (var level in _levels) {
            if (level.TreeNumber.Length != _treePrefab.Length) {
                throw new System.Exception("Number of trees in levels has to be equal to number of prefabs");
            }
        }

        if (_resetGame) {
            SaveData();
        }
        else {
            LoadData();
        }
        GenerateLevel(_currentLevel);
    }

    void Update() {
        if (Input.GetButtonDown("Cancel")) {
            Application.Quit();
        }
    }

    public bool NextLevelEnabled() {
        if (GetNumberOfTrees() <= _totalTrees / 2) {
            return true;
        }
        else {
            return false;
        }
    }

    public void NextLevel() {
        foreach (GameObject obj in _trees) {
            if (obj) {
                Destroy(obj);
            }
        }
        _currentLevel = (_currentLevel + 1) % _levels.Length;
        _trees.Clear();
        SaveData();
        GenerateLevel(_currentLevel);
    }

    public void SaveData() {
        PlayerPrefs.SetInt("Coin Amount", _upgradeSystem.CoinAmount);
        PlayerPrefs.SetInt("Saw Level", _upgradeSystem._upgradeSaw.Level);
        PlayerPrefs.SetInt("Capacity Level", _upgradeSystem._upgradeCapacity.Level);
        PlayerPrefs.SetInt("Speed Level", _upgradeSystem._upgradeSpeed.Level);
        PlayerPrefs.SetInt("Level", _currentLevel);
    }

    public void LoadData() {
        _upgradeSystem.CoinAmount = PlayerPrefs.GetInt("Coin Amount", 0);
        _upgradeSystem._upgradeSaw.Level = PlayerPrefs.GetInt("Saw Level", 0);
        _upgradeSystem._upgradeCapacity.Level = PlayerPrefs.GetInt("Capacity Level", 0);
        _upgradeSystem._upgradeSpeed.Level = PlayerPrefs.GetInt("Speed Level", 0);
        _currentLevel = PlayerPrefs.GetInt("Level", 0);
    }

    public int GetNumberOfTrees() {
        int number = 0;
        foreach (GameObject obj in _trees) {
            if (obj) {
                number++;
            }
        }
        return number;
    }

    private void GenerateLevel(int level) {
        for (int i = 0; i < _treePrefab.Length; i++) {
            for (int j = 0; j < _levels[_currentLevel].TreeNumber[i]; j++) {
                float x = Random.Range(_leftBorder, _rightBorder);
                float z = Random.Range(_forwardBorder, _backwardBorder);
                _trees.Add(Instantiate(_treePrefab[i], new Vector3 (x, 0.0f, z), Quaternion.identity));
            }
        }

        _totalTrees = _trees.Count;
    }
}
