using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement Parameters")]

    [SerializeField] float _forwardSpeed;
    [SerializeField] float _sideSpeed;

    bool _isMovementAllowed;
    Rigidbody _rigidbody;
    Vector3 _movementVector;
    Touch touch;

    private void Start()
    {
        //Components
        _rigidbody = GetComponent<Rigidbody>();

        //Events
        C_GameManager.OnGameStarted += C_GameManager_OnGameStarted;

    }

    private void C_GameManager_OnGameStarted()
    {
        _isMovementAllowed = true;
    }

    private void FixedUpdate()
    {
        if (_isMovementAllowed)
        {
            _rigidbody.velocity = _movementVector * Time.fixedDeltaTime * 100f;
        }
        
    }
    private void Update()
    {
        //GetTouchInput();
        //DetermineSideMovement();
        if (_isMovementAllowed)
        {
            DetermineSideMovementForKeyboard();
            Move();
        }

      //  ClampPosAtX();
    }

    void Move()
    {
        _movementVector.y = 0f;
        _movementVector.z = _forwardSpeed;

    }


    void DetermineSideMovement()
    {
        
        if (touch.phase == TouchPhase.Moved)
        {
            if (touch.deltaPosition.x > 0)
            {
                _movementVector.x = _sideSpeed;
            }
            else
            {
                _movementVector.x = -1f * _sideSpeed;
            }
        }
        else
        {
            _movementVector.x = 0f;
        }

    }

    private void GetTouchInput()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
        }
    }

    void DetermineSideMovementForKeyboard()
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

    private void ClampPosAtX()
    {
        Vector3 _clampPos = transform.position;
        _clampPos.x = Mathf.Clamp(_clampPos.x, -3.7f, 3.7f);
        transform.position = _clampPos;
    }

    private void OnDestroy()
    {
        C_GameManager.OnGameStarted -= C_GameManager_OnGameStarted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            _rigidbody.isKinematic = true;
            _isMovementAllowed = false;
        }
    }
}
