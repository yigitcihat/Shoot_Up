using System.Collections;
using System.Collections.Generic;
using UISystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ProgresBar : MonoBehaviour
{
    
    [SerializeField] private Slider _progressBar;
    [SerializeField] private Text _scoretext;
    public GameObject heykel;
    public float currentCheckPoint;
    public float parts;
    public bool isDesroyed = false;
    private bool isFinished = false;


    private void Update()
    {
        if (!isFinished)
        {
            CheckBox();
        }
        
        if (isDesroyed)
        {
            StartCoroutine(WaitAndActive());
        }
    }
    public void CheckBox()
    {
        int enableBoxs = 0;
        BoxCollider[] boxColliders = GetComponentsInChildren<BoxCollider>();
        foreach (BoxCollider box in boxColliders)
        {
            if (box.enabled == true)
            {
                enableBoxs += 1;
            }
    
        }
        currentCheckPoint = enableBoxs;
        float progressValue = (float)(currentCheckPoint / parts ) * 100;
        _progressBar.value = progressValue;
        if (progressValue <= 30)
        {
            isDesroyed = true;
        }

    }
    private IEnumerator WaitAndActive()
    {
        
        _progressBar.value = 0;
        _scoretext.text = "500";
        yield return new WaitForSeconds(3f);
        
        isFinished = true;
        isDesroyed = false;
        UImanager.Instance().OpenPanel(UIPanelTypes.tutorial);
        heykel.SetActive(true);


    }



}
