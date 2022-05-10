using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

public class Player : MonoBehaviour {
    [System.NonSerialized] public Characteristics _characteristics;
    public UpgradeSystem _upgradeSystem;

    public void CreateEntity(EcsWorld world) {
        var entity = world.NewEntity();

        ref var transformRef = ref entity.Get<TransformRef>();
        transformRef.Transform = transform;

        ref var rigidbodyRef = ref entity.Get<RigidbodyRef>();
        rigidbodyRef.Rigidbody = GetComponent<Rigidbody>();

        ref var characteristics = ref entity.Get<Characteristics>();
        characteristics._upgradeSystem = _upgradeSystem;
        characteristics.Logs = new List<LogAnimation>();
        _characteristics = characteristics;
    }
}
