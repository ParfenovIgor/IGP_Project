using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelSaw {
    public int Cost;
    public float Damage;
}

[System.Serializable]
public struct UpgradeSaw {
    public int Level;
    public LevelSaw[] Levels;
    
    public float GetDamage() {
        return Levels[Level].Damage;
    }

    public void Upgrade(ref int coins) {
        if (Level < MaxLevel()) {
            if (coins >= Levels[Level + 1].Cost) {
                Level++;
                coins -= Levels[Level].Cost;
            }
        }
    }

    public System.String GetCostText() {
        if (Level < MaxLevel()) {
            return "Saw: " + Levels[Level + 1].Cost.ToString();
        }
        else {
            return "Saw: Max Level";
        }
    }

    public int MaxLevel() {
        return Levels.Length - 1;
    }
}
