using UnityEngine;

public class Pointer : MonoBehaviour {
    private Transform _pivotTransform;

    private void Start() {
        _pivotTransform = PlayerController.Instance.transform;
    }

    private void Update() {
        transform.position = _pivotTransform.position;

        Coin target = GameManager.Instance.GetNearestCoin(transform.position);

        if (!target) return;

        Vector3 direction = target.transform.position - transform.position;

        direction.y = 0;

        transform.rotation = Quaternion.RotateTowards(transform.rotation,
                                                      Quaternion.LookRotation(direction),
                                                      Time.deltaTime * 180f);
    }
}
