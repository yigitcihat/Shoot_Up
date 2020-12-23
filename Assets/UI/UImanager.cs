﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace UISystems
{
    public class UImanager : MonoBehaviour
    {
    

        private static UImanager _instance;

        [HideInInspector]
        public GenericUIPanelController currentUIPanelController;

        public GenericUIPanelController previousUIPanelController;

        [SerializeField]
        private PanelHolder[] uiPanels;
        public bool startButton;
        



        public static UImanager Instance()
        {
            return _instance;
        }

        private void Awake()
        {
            if(_instance == null)
            {
                _instance = this;
            }
            DontDestroyOnLoad(gameObject);
        }

    
        public void OpenPanel(UIPanelTypes panel, bool isCache = false)
        {
            var panelHolder = uiPanels.FirstOrDefault(x => x.type == panel);
            panelHolder.uiPanel.SetActive(true);
            var controller = panelHolder.uiPanel.GetComponent<GenericUIPanelController>();

            if (isCache)
            {
                previousUIPanelController = currentUIPanelController;
            }

            currentUIPanelController = controller;
        }

        public void ClosePanel(UIPanelTypes panel)
        {

            var panelHolder = uiPanels.FirstOrDefault(x => x.type == panel);
            panelHolder.uiPanel.SetActive(false);

            if (previousUIPanelController)
            {
                //previousUIPanelController.OpenPanel();
                currentUIPanelController = previousUIPanelController;
                previousUIPanelController = null;
            }
        }
    }

    [System.Serializable]
    public class PanelHolder
    {
        public GameObject uiPanel;
        public UIPanelTypes type;

    }
}

