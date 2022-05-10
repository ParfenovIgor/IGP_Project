using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class InitSystem : IEcsInitSystem {
    private Player _player;
    private EcsWorld _world;

    public void Init() {
        _player.CreateEntity(_world);
    }
}
