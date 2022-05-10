using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class Startup : MonoBehaviour {
    [SerializeField] private Player _player;
    private EcsSystems _systems;
    private EcsWorld _world;

    private void Start() {
        _world = new EcsWorld();
        _systems = new EcsSystems(_world)
            .Add(new InitSystem())
            .Add(new PlayerMovementSystem())
            .Inject(_player);
        _systems.Init();
    }

    private void Update() {
        _systems.Run();
    }

    private void OnDestroy() {
        _systems.Destroy();
        _world.Destroy();
    }
}
