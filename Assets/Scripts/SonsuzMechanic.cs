using System;
using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SonsuzMechanic : MonoBehaviour
{
    private bool _isMoving;
    private bool _isTouching;
    private bool _isStationary;

    private Vector3 _startPosForInfinity;
    private Vector3 _currentPosForInfinity;
    [SerializeField] private Animator _heykelAnimator;

    [SerializeField] private GameObject _tutorialObject;
    [SerializeField] private InputManager _inputManager;

    private void Start()
    {
        _inputManager.enabled = false;
    }

    void Update()
    {
        if (_heykelAnimator.GetCurrentAnimatorStateInfo(0).IsName("Finished"))
        {
            _tutorialObject.SetActive(false);
            UImanager.Instance().OpenPanel(UIPanelTypes.scoreBoard);
            Debug.Log("Finished");
            Time.timeScale = 1;
        }
        else
        {
            InfinityMechanic();
        }
        
        if (Input.touchCount > 0)
        {
            foreach (var touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        _isTouching = true;
                        _startPosForInfinity = touch.position;
                        break;
                    case TouchPhase.Moved:
                        _currentPosForInfinity = touch.position;
                        _isMoving = true;
                        _isStationary = false;
                        break;
                    case TouchPhase.Stationary:
                        _startPosForInfinity = touch.position;
                        _isMoving = false;
                        _isStationary = true;
                        break;
                    case TouchPhase.Ended:
                        _isTouching = false;
                        _isMoving = false;
                        _isStationary = false;
                        break;
                    case TouchPhase.Canceled:
                        _isTouching = false;
                        _isMoving = false;
                        _isStationary = false;
                        break;
                }
            }
        }
    }

    private void InfinityMechanic()
    {
        if (_isTouching && _isMoving && (Mathf.Abs(Vector3.Distance(_startPosForInfinity,_currentPosForInfinity))) >= 100)
        {
            Time.timeScale = 0.3f;
        }
        else if (_isTouching && _isStationary)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 0;
        }

    }
}


