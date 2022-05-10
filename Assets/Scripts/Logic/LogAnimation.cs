using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LogAnimation : MonoBehaviour {
    public int _cost;
    [SerializeField] private Vector3 _pilePosition;
    [SerializeField] private int _numberInRow;
    [SerializeField] private float _rowHeight, _rowWidth;
    [SerializeField] private Vector3 _truckPosition;
    private bool _inTruck = false;

    void OnTriggerEnter(Collider collider) {
        Player player = collider.GetComponent<Player>();
        if (!_inTruck && player && player._characteristics.Logs.Count < player._characteristics.GetCapacity()) {
            transform.parent = player.transform;

            int n = player._characteristics.Logs.Count;
            player._characteristics.Logs.Add(this);

            Vector3 position = new Vector3 (-(_rowWidth / 2) + (_rowWidth / (_numberInRow - 1)) * (n % _numberInRow), (n / _numberInRow) * _rowHeight, 0.0f) + _truckPosition;

            transform.DOLocalJump(position, 3.0f, 1, 1.0f);
            transform.DOLocalRotate(new Vector3 (0.0f, 90.0f, 0.0f), 1.0f);

            _inTruck = true;
        }
    }

    public void FloatToPile() {
        transform.DOJump(_pilePosition, 3.0f, 1, 1.0f).OnKill(DestroyAtEnd);
        transform.DORotate(new Vector3 (0.0f, 90.0f, 0.0f), 1.0f);
    }

    private void DestroyAtEnd() {
        Destroy(gameObject);
    }
}
