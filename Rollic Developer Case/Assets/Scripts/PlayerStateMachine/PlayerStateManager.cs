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
    Collector _collector;

    // Movement 

    Vector3 _movementVector;
    [SerializeField] float _forwardSpeed;
    [SerializeField] float _sideSpeed;

    // Getters & Setters
    public PlayerBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }
    public Collector Collector { get => _collector; set => _collector = value; }

    

    private void Awake()
    {
        // Assign first state

        _states = new PlayerStateFactory(this);
        CurrentState = _states.Idle();
        CurrentState.EnterState();

        // Get components

        Rigidbody = GetComponent<Rigidbody>();
        Collector = GetComponent<Collector>();

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
        Rigidbody.velocity = _movementVector * Time.fixedDeltaTime * 100f;
    }

    #endregion
}
