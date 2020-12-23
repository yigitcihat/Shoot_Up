using System;
using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;
using UnityEngine.UI;


public class BonusController : MonoBehaviour
{
    #region Singleton
    private static BonusController _instance;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static BonusController GetInstance()
    {
        return _instance;
    }
    #endregion

    public GameObject heykel1;

    public int objectNumber = 0;
    void Update()
    {
        if (objectNumber >= 5)
        {
            //MEKANİK
            UImanager.Instance().OpenPanel(UIPanelTypes.tutorial);

            heykel1.SetActive(true);
        }
    }
}
