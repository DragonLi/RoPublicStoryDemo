using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MainControl : MonoBehaviour
{
    [SerializeField] private GameObject bookListGameObject;
    [SerializeField] private GameObject logoGameObject;
    
    private Dictionary<string,BookControl> bookList = new Dictionary<string,BookControl>();
    
    private const int LOGO_SECONDS = 5;
    private const string LOGOPATH = "LogoCanvas";
 
    #region sample book demo
    
    private const string SAMPLE_BOOK_NAME = "My birthday";
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InitGameObjects();
        //AskUserInto();
        SearchBooks();
        HideBooks();
        
        StartCoroutine(ShowLogo());
    }
    
    [SerializeField] private Fungus.Flowchart testChart;
    private void AskUserInto(){
        testChart.SendFungusMessage("StartAskUser");
    }

    private void InitGameObjects()
    {        
#if UNITY_EDITOR
        Assert.raiseExceptions = true;
        CheckResource();        
#endif
    }

    public void CheckResource()
    {
        Assert.IsTrue(bookListGameObject != null);
        Assert.IsTrue(logoGameObject != null);
        Assert.IsTrue(testChart != null);
    }

    private void SearchBooks()
    {
        var lst = bookListGameObject.GetComponentsInChildren<BookControl>(true);
        foreach (var ctl in lst)
        {
            bookList.Add(ctl.bookName,ctl);
        }
    }

    private void HideBooks()
    {
        foreach (var ctl in bookList.Values)
        {
            ctl.Hide();
        }
    }

    private IEnumerator ShowLogo()
    {
        logoGameObject.SetActive(true);
        yield return new WaitForSeconds(LOGO_SECONDS);
        //hide logo
        logoGameObject.SetActive(false);
        
        //ShowBook(SAMPLE_BOOK_NAME);
        AskUserInto();
    }

    private void ShowBook(string bookName)
    {
        BookControl ctl;
        if (bookList.TryGetValue(bookName, out ctl))
        {
            ctl.StartShowBook();
        }
    }
}
