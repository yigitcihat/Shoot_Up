using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusScene : MonoBehaviour
{
    [SerializeField] private GameObject _obje1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            BonusController.GetInstance().objectNumber++;
            _obje1.SetActive(true);
            gameObject.SetActive(false);
            Destroy(other.gameObject,1);
        }
    }
}
