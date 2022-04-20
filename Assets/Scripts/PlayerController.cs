using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour {
    public static PlayerController Instance { get; private set; }

    public float Speed;

    private Rigidbody _rg;

    [SerializeField] private Transform _cameraPivot;

    private void Awake() {
        Instance = this;

        _rg = GetComponentInChildren<Rigidbody>();
        _rg.maxAngularVelocity = 15f;
    }

    private void FixedUpdate() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = _cameraPivot.transform.right * v + _cameraPivot.transform.forward * -h;

        _rg.AddTorque(move * Speed);
    }
}
