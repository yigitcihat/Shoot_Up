using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;

public class TutorialController : GenericUIPanelController
{
    public override void ClosePanel()
    {
       
        UImanager.Instance().ClosePanel(UIPanelTypes.tutorial);
    }

    public override void OpenPanel()
    {
        this.gameObject.SetActive(true);

    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.J))
        {
            ClosePanel();
        }
    }
}
