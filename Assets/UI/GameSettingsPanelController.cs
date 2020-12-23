﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISystems;
using UnityEngine.SceneManagement;



public class GameSettingsPanelController : GenericUIPanelController
{
    public override void ClosePanel()
    {
        UImanager.Instance().ClosePanel(UIPanelTypes.gameSettingsPanel);
    }

    public override void OpenPanel()
    {
        this.gameObject.SetActive(true);

    }
    public void RestartButonFunc()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        ClosePanel();

    }
    public void RemoveAdsButonFunc()
    {
        ClosePanel();
    }
    public void BackMenuButonFunc()
    {
        ClosePanel();
        UImanager.Instance().ClosePanel(UIPanelTypes.gamePanel);
        UImanager.Instance().OpenPanel(UIPanelTypes.mainMenuPanel, true);

    }

}
