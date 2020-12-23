using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UISystems;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class InputManager : MonoBehaviour
{
    #region Singleton
    private static InputManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }
    public static InputManager GetInstance()
    {
        return _instance;
    }
    #endregion
    
    #region Variables
    
    private bool _shouldPredict;
    private Vector3 _startPos;
    private Vector3 _currentPos;

    public Shooter shooter;
    public Predicter predicter;

    #endregion

    private void Start()
    {
        
    }

    private void Update()
    {
            predicter.DrawRaycast();
            // if (Input.GetMouseButton(0) )
            // {
            //     Debug.Log("aklsdjklf");
            //     FillBar.GetInstance().mustMove = true;
            //     FillBar.GetInstance().FillBarPingPong();
            //     Predicter.GetInstance()._lineRenderer.SetPosition(1, Predicter.GetInstance().hit.point);
            // }
            // else
            // {
            //     Debug.Log("");
            // }
            //
            // if (Input.GetMouseButtonUp(0) )
            // {
            //     FillBar.GetInstance().mustMove = false;
            //     Shooter.GetInstance().ThrowBall(Predicter.GetInstance().hit);
            //     StartCoroutine(Shooter.GetInstance().CameraShake(0.5f, 1f));
            // }
            // else
            // {
            //     Debug.Log("");
            // }
        

        if (Input.touchCount <= 0) return;
            foreach (var touch in Input.touches)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:

                        OnTouchBegan(touch);
                        break;
                    case TouchPhase.Moved:
                        OnTouchMoved(touch);
                        break;
                    case TouchPhase.Stationary:
                        OnTouchStationary(touch);
                        break;
                    case TouchPhase.Ended:
                        OnTouchEnded();
                        break;
                    case TouchPhase.Canceled:
                        OnTouchCancelled();
                        break;
                    default:
                        Debug.Log("Default!!");
                        break;
                }
            }
        
        
        
    }
    
    #region Private Methods
    
    private void OnTouchBegan(Touch touch)
    {
        predicter.hitPoint.SetActive(true);
        predicter._predicterObject.transform.localRotation = Quaternion.identity;
        predicter._lineRenderer.enabled = true;
        predicter._lineRenderer.SetPosition(1,predicter.hit.point);
        FillBar.GetInstance().mustMove = true;
        _startPos = touch.position;
    }

    private void OnTouchMoved(Touch touch)
    {
        FillBar.GetInstance().FillBarPingPong();
        _currentPos = touch.position;
        predicter._lineRenderer.SetPosition(1,predicter.hit.point);
        predicter.CalculateXAxisMovement(_startPos,_currentPos);
        predicter.CalculateYAxisMovement(_startPos,_currentPos);
    }

    private void OnTouchStationary(Touch touch)
    {
        _currentPos = touch.position;
        FillBar.GetInstance().FillBarPingPong();
        predicter._lineRenderer.SetPosition(1,predicter.hit.point);
        // Predicter.GetInstance().CalculateXAxisMovement(_startPos,_currentPos);
        // Predicter.GetInstance().CalculateYAxisMovement(_startPos,_currentPos);
    }

    private void OnTouchEnded()
    {
        predicter.hitPoint.SetActive(false);
        FillBar.GetInstance().mustMove = false;
        predicter._lineRenderer.enabled = false;
        _startPos = Vector3.zero;
        _currentPos = Vector3.zero;
        shooter.ThrowBall(predicter.hit);
        StartCoroutine(shooter.CameraShake(0.5f, 1f));
    }

    private void OnTouchCancelled()
    {
        FillBar.GetInstance().mustMove = false;
        predicter._lineRenderer.enabled = false;
        _startPos = Vector3.zero;
        _currentPos = Vector3.zero;
        shooter.ThrowBall(predicter.hit);
    }
    
    #endregion
    
}
