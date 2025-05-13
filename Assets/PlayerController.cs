using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    Rigidbody RB;

    [field: SerializeField]
    public float Speed { get; set; } = 15;

    private void Start()
    {
        if(RB == null)
            RB = GetComponent<Rigidbody>();

        Assert.IsNotNull(RB);
    }

    private void Update()
    {
        if (!_controls_enabled)
            return;

        var velocity = Vector3.zero;
            if (Input.GetKeyDown(KeyCode.W))
                velocity += new Vector3(0f, 0f, 1f) * Speed;
            if (Input.GetKeyDown(KeyCode.S))
                velocity += new Vector3(0f, 0f, -1f) * Speed;
            if (Input.GetKeyDown(KeyCode.A))
                velocity += new Vector3(-1f, 0f, 0f) * Speed;
            if (Input.GetKeyDown(KeyCode.D))
                velocity += new Vector3(1f, 0f, 0f) * Speed;

            _nextVelocity = velocity;
    }

    private void LateUpdate()
    {
        if (!_controls_enabled)
            return;


        RB.velocity = _nextVelocity;
    }

    bool _controls_enabled = true;
    Vector3 _nextVelocity = Vector3.zero;
    Rigidbody _rb;
}
