using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelCapacity {
    public int Cost, Capacity;
}

[System.Serializable]
public struct UpgradeCapacity {
    public int Level;
    public LevelCapacity[] Levels;
    
    public int GetCapacity() {
        return Levels[Level].Capacity;
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
            return "Capacity: " + Levels[Level + 1].Cost.ToString();
        }
        else {
            return "Capacity: Max Level";
        }
    }

    public int MaxLevel() {
        return Levels.Length - 1;
    }
}
