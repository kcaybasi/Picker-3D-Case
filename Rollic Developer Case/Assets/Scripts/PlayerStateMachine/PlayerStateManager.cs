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
    Counter _counter;

    [Header("Movement Parameters")]

    Vector3 _movementVector;
    float _forwardSpeed=5f;
    float _sideSpeed=3f;
    Touch touch;

    [Header("Counter Routine")]

    [SerializeField] Material _platformColor;
    Color _counterTargetColor;



    // Getters & Setters
    public PlayerBaseState CurrentState { get => _currentState; set => _currentState = value; }
    public Rigidbody Rigidbody { get => _rigidbody; set => _rigidbody = value; }
    public Collector Collector { get => _collector; set => _collector = value; }
    public Counter Counter { get => _counter; set => _counter = value; }
    public Color CounterTargetColor { get => _counterTargetColor;  }

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

        // Assign counter color to platform color

        _counterTargetColor = _platformColor.color;
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

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > 0)
                {
                    _movementVector.x = _sideSpeed;
                }
                else if (touch.deltaPosition.x < 0)
                {
                    _movementVector.x = _sideSpeed * -1f;
                }
            }
            else
            {
                _movementVector.x = 0;
            }


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
