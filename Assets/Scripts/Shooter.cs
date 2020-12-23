using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Shooter : MonoBehaviour
{

    
    #region Variables
    
    public GameObject _objPrefab;
    [SerializeField] private GameObject _camera;
    private Vector3 _originalCameraPosition;
    [SerializeField] private Transform _shootPoint;
    public Predicter predicterShooter;

    #endregion

    #region Public Methods

    public void ThrowBall(RaycastHit _hit)
    {
        Vector3 pos = _hit.point;
        GameObject ball = Instantiate(_objPrefab,_shootPoint.position,Quaternion.identity);//Instantiated our real ball.
        ball.tag = "ball";//Set tag to ball.
        ball.GetComponent<Rigidbody>().AddForce((pos - predicterShooter._predicterObject.transform.position)*FillBar.GetInstance().CalculateShootingForce(FillBar.GetInstance()._fillBar, FillBar.GetInstance()._magnitude));
    }

    public IEnumerator CameraShake(float magnitude, float duration)
    {

        _originalCameraPosition = _camera.transform.position;
        _camera.transform.DOShakePosition(duration, magnitude, 10, 90f);
        yield return new WaitForSeconds(duration);
        _camera.transform.position = _originalCameraPosition;
    }

    #endregion
    
}
