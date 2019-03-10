using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MainControl : MonoBehaviour
{
    [SerializeField] private GameObject bookListGameObject;
    
    private Dictionary<string,BookControl> bookList = new Dictionary<string,BookControl>();
    
    #region sample book demo
    
    private const string SAMPLE_BOOK_NAME = "My birthday";
    
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        InitGameObjects();
        SearchBooks();
        HideBooks();
        
        //ShowBook(SAMPLE_BOOK_NAME);
        AskUserInto();
    }
    
    [SerializeField] private Fungus.Flowchart askUserFlow;
    private BookControl askUserInfoCtl;
    private void AskUserInto(){
        //askUserFlow.SendFungusMessage("StartFrontPage");
        askUserInfoCtl.StartShowBook();
    }

    private void InitGameObjects()
    {
        askUserInfoCtl = askUserFlow.GetComponent<BookControl>();
#if UNITY_EDITOR
        Assert.raiseExceptions = true;
        CheckResource();        
#endif
    }

    public void CheckResource()
    {
        Assert.IsTrue(bookListGameObject != null);
        Assert.IsTrue(askUserFlow != null);
        Assert.IsNotNull(askUserInfoCtl);
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

    private void ShowBook(string bookName)
    {
        BookControl ctl;
        if (bookList.TryGetValue(bookName, out ctl))
        {
            ctl.StartShowBook();
        }
        #if UNITY_EDITOR
        else{
            Debug.Log("Can't not show book: book not found: "+bookName);
        }
        #endif
    }
}
