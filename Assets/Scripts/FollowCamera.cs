using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour {
    private Transform _targetTransform;
    private Rigidbody _targetRigidbody;

    [SerializeField] private List<Vector3> _velocitiesList = new List<Vector3>();

    private void Start() {
        _targetTransform = PlayerController.Instance.transform;
        _targetRigidbody = PlayerController.Instance.GetComponent<Rigidbody>();
        
        for (int i = 0; i < 10; i++) {
            _velocitiesList.Add(transform.forward);
        }
    }

    private void Update() {
        transform.position = _targetTransform.position;

        Vector3 direction = GetSumVelocity();
        
        direction.y = 0;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
    }

    private void FixedUpdate() {
        Vector3 velocity = _targetRigidbody.velocity;
        
        if (velocity.magnitude < 1f) return;
        
        _velocitiesList.Add(velocity);
        _velocitiesList.RemoveAt(0);
    }

    private Vector3 GetSumVelocity() {
        Vector3 sum = Vector3.zero;

        foreach (var tmp in _velocitiesList) {
            sum += tmp;
        }

        return sum;
    } 
}
