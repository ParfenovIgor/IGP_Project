using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelSpeed {
    public int Cost;
    public float SpeedMovement, SpeedRotation;
}

[System.Serializable]
public struct UpgradeSpeed {
    public int Level;
    public LevelSpeed[] Levels;
    
    public float GetSpeedMovement() {
        return Levels[Level].SpeedMovement;
    }
    
    public float GetSpeedRotation() {
        return Levels[Level].SpeedRotation;
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
            return "Speed: " + Levels[Level + 1].Cost.ToString();
        }
        else {
            return "Speed: Max Level";
        }
    }

    public int MaxLevel() {
        return Levels.Length - 1;
    }
}
