using Fungus;
using UnityEngine;

public class BookControl : MonoBehaviour
{
    private const string PAGELIST_PATH = "PageList";
    private const string FRONT_PAGE_NAME = "StartFrontPage";
    private GameObject pageListObj;

    // Start is called before the first frame update
    void Start()
    {
        var trans = this.transform.Find(PAGELIST_PATH);
        pageListObj = trans.gameObject;
        pageListObj.SetActive(false);
    }

    public void StartShowBook()
    {
        pageListObj.SetActive(true);
        
        var bookFlowchart = this.GetComponent<Flowchart>();
        bookFlowchart.SendFungusMessage(FRONT_PAGE_NAME);

    }
}
