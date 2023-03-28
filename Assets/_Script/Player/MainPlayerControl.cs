using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainPlayerControl : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 10;

    [SerializeField]
    private float _rotateSpeed = 10;

    [SerializeField]
    private Animator _pAnimator = null;

    public event EventHandler<HealthChangeEvent> _healthChange;

    public static readonly int MOVE = Animator.StringToHash("Move");
    public static readonly int STOP = Animator.StringToHash("Stop");


    #region Unity Core
    void Start()
    {

    }

    private float _horizontalValue = 0;
    private float _verticalValue = 0;

    private bool _hasMoving = false;

    void Update()
    {
        _horizontalValue = Input.GetAxis("Horizontal");
        _verticalValue = Input.GetAxis("Vertical");

        if (_horizontalValue != 0 || _verticalValue != 0)
        {
            if (!_hasMoving)
            {
                _hasMoving = true;
                _pAnimator.SetTrigger(MOVE);
            }

            Vector3 moveDirection = new Vector3(_horizontalValue, 0, _verticalValue);

            transform.position += moveDirection * _moveSpeed * Time.deltaTime;

            transform.LookAt(transform.position + moveDirection);

            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        else
        {
            if (_hasMoving)
            {
                _hasMoving = false;
                _pAnimator.SetTrigger(STOP);
            }
        }
    }
    #endregion

    [SerializeField]
    private int _playerHealth = 10;

    public int PlayerHealth
    {
        get { return _playerHealth; }

        set
        {
            _playerHealth = value;
            _healthChange.Invoke(this, new HealthChangeEvent { Health = _playerHealth });
        }
    }
}
