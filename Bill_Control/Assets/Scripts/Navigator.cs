using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{

    [SerializeField] private CanvasGroup mainMenuPanel;
    [SerializeField] private CanvasGroup companyPanel;
    [SerializeField] private CanvasGroup typePanel;
    [SerializeField] private CanvasGroup loadBillsPanel;

    public float showSpeed = 1;

    //[SerializeField] private GameObject showUsers;
    //[SerializeField] private GameObject loadUsers;

    public void LoadMainMenu()
    {
        StopAllCoroutines();
        UnloadPanel(companyPanel);
        UnloadPanel(typePanel);
        UnloadPanel(loadBillsPanel);
        LoadPanel(mainMenuPanel);
    }
    public void LoadCompany()
    {
        StopAllCoroutines();
        UnloadPanel(mainMenuPanel);
        LoadPanel(companyPanel);
    }
    public void LoadType()
    {
        StopAllCoroutines();
        UnloadPanel(mainMenuPanel);
        LoadPanel(typePanel);
    }
    public void LoadBills()
    {
        StopAllCoroutines();
        UnloadPanel(mainMenuPanel);
        LoadPanel(loadBillsPanel);
    }

    private void UnloadPanel(CanvasGroup panel)
    {
        StartCoroutine(UnloadPanelCoroutine(panel));
    }
    private void LoadPanel(CanvasGroup panel)
    {
        StartCoroutine(LoadPanelCoroutine(panel));
    }

    IEnumerator UnloadPanelCoroutine(CanvasGroup panel)
    {
        if (panel.alpha > 0)
        {
            float t = 1;
            while (t > 0)
            {
                panel.alpha = Mathf.Lerp(0, 1, t);
                t -= Time.deltaTime * showSpeed;
                yield return null;
            }
            panel.alpha = 0;
            panel.interactable = false;
            panel.blocksRaycasts = false;
        }
    }

    IEnumerator LoadPanelCoroutine(CanvasGroup panel)
    {
        float t = 0;
        while (t < 1)
        {
            panel.alpha = Mathf.Lerp(0, 1, t);
            t += Time.deltaTime * showSpeed;
            yield return null;
        }
        panel.alpha = 1;
        panel.interactable = true;
        panel.blocksRaycasts = true;
    }

}
