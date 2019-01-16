using System;
using System.Collections;
using Fungus;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Flowchart))]
public class BookControl : MonoBehaviour
{
    [SerializeField] public string bookName;
    
    private const string PAGELIST_PATH = "PageList";
    private const string FRONT_PAGE_NAME = "StartFrontPage";
    private GameObject pageListObj;
    private Flowchart bookFlowchart;

    // Start is called before the first frame update
    void Start()
    {
        InitGameObjects();

        //pageListObj.SetActive(false);
        Debug.Log(bookName+" book control start");
    }

    private void InitGameObjects()
    {
        var trans = transform.Find(PAGELIST_PATH);
        pageListObj = trans.gameObject;
        bookFlowchart = GetComponent<Flowchart>();
        
#if UNITY_EDITOR
        CheckResource();        
#endif
    }

    private void CheckResource()
    {
        Assert.IsTrue(pageListObj != null);
        Assert.IsTrue(bookFlowchart != null);
        Assert.IsFalse(string.IsNullOrEmpty(bookName));
    }

    public void StartShowBook()
    {
        gameObject.SetActive(true);
        
        StartCoroutine(StartFrontPage());
    }

    private IEnumerator StartFrontPage()
    {
        yield return null;
        pageListObj.SetActive(true);
        yield return null;
        bookFlowchart.SendFungusMessage(FRONT_PAGE_NAME);
    }

    public void Hide()
    {
        gameObject.SetActive(false);

#if UNITY_EDITOR
        Assert.IsFalse(string.IsNullOrEmpty(bookName),"Invalid book name");
#endif
    }
}
