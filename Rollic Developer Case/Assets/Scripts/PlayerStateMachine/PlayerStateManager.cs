using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerStateManager : MonoBehaviour
{
    // States

    PlayerBaseState _currentState;
    PlayerStateFactory _states;

    // Components

    Rigidbody _rigidbody;

    // Movement 

    Vector3 _movementVector;
    [SerializeField] float _forwardSpeed;
    [SerializeField] float _sideSpeed;

    // Getters & Setters
    public PlayerBaseState CurrentState { get => _currentState; set => _currentState = value; }
    private void Awake()
    {
        // Assign first state

        _states = new PlayerStateFactory(this);
        CurrentState = _states.Idle();
        CurrentState.EnterState();

        // Get components

        _rigidbody = GetComponent<Rigidbody>();

        // Assign movement vector

        DetermineMovementVector();
    }

    void Update()
    {
        CurrentState.UpdateState();
    }

    private void FixedUpdate()
    {
        CurrentState.FixedUpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        CurrentState.OnTriggerEnter(other);
    }

    #region Movement Methods

    public void CalculateSideMovementVector()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _movementVector.x = _sideSpeed;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _movementVector.x = _sideSpeed * -1f;
        }
        else
        {
            _movementVector.x = 0f;
        }
    }

    void DetermineMovementVector()
    {
        _movementVector.y = 0f;
        _movementVector.z = _forwardSpeed;
    }

    public void Move()
    {
        CalculateSideMovementVector();
        _rigidbody.velocity = _movementVector * Time.fixedDeltaTime * 100f;
    }

    #endregion
}
