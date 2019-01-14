using System.Collections;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    private const int LOGO_SECONDS = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowLogo());
    }

    private IEnumerator ShowLogo()
    {
        yield return new WaitForSeconds(LOGO_SECONDS);
        //hide logo
        var obj = GameObject.Find("LogoCanvas");
        obj.SetActive(false);
        
        ShowBook("SampleBookFlowchart");
    }

    private static void ShowBook(string bookName)
    {
        var obj = GameObject.Find(bookName);
        var ctl = obj.GetComponent<BookControl>();
        ctl.StartShowBook();
    }
}
