using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5;

    [SerializeField]
    private float _rangeAttack = 2f;

    [SerializeField]
    private Animator _bAnimator = null;

    [SerializeField]
    private LayerMask layerMask;

    private Transform _targetTransform;

    private bool _isStartMoving = false;
    private bool _startAttack = false;

    private static readonly int MOVE = Animator.StringToHash("Move");
    private static readonly int STOP = Animator.StringToHash("Stop");
    private static readonly int ATTACK = Animator.StringToHash("Attack");

    #region UNITY_CORE

    private void OnEnable()
    {

    }

    private void Update()
    {
        if (_targetTransform != null)
        {


            float distance = Vector3.Distance(_targetTransform.position, transform.position);

            if (distance > _rangeAttack)
            {
                if (!_isStartMoving)
                {
                    _isStartMoving = true;

                    _bAnimator.SetTrigger(MOVE);
                }

                transform.position += transform.forward * _moveSpeed * Time.deltaTime;

                transform.LookAt(_targetTransform.position);

                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }
            else
            {
                if (_isStartMoving)
                {
                    _isStartMoving = false;

                    _bAnimator.SetTrigger(STOP);

                    SlimeNormalAttack();
                }
            }
        }
    }
    #endregion


    private void SlimeNormalAttack()
    {
        _bAnimator.SetTrigger(ATTACK);
    }



    public void SetTargetTransform(Transform targetTrasnform)
    {
        _targetTransform = targetTrasnform;
    }

    private void OnBotDead()
    {
        ObjectPool.PushToPool(gameObject);
    }
}
