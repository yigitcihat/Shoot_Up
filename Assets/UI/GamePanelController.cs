using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UISystems;

public class GamePanelController : GenericUIPanelController
   
{
    bool gamesettingcheck = true;
    public override void ClosePanel()
    {
        UImanager.Instance().ClosePanel(UIPanelTypes.gameSettingsPanel);
        

    }

    public override void OpenPanel()
    {
        this.gameObject.SetActive(true);
    }
    public void settingsButtonFunc()
    {
        if (gamesettingcheck)
        {
            UImanager.Instance().OpenPanel(UIPanelTypes.gameSettingsPanel, true);
            gamesettingcheck = false;
        }
        else
        {
            ClosePanel();
            gamesettingcheck = true;
        }
    }
}
