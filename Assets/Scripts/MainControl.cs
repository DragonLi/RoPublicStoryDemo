using System.Collections;
using UnityEngine;

public class MainControl : MonoBehaviour
{
    private const int LOGO_SECONDS = 5;
    private const string LOGOPATH = "LogoCanvas";
    private GameObject logo;

    // Start is called before the first frame update
    void Start()
    {
        logo = this.transform.Find(LOGOPATH).gameObject;
        logo.SetActive(true);

        StartCoroutine(ShowLogo());
    }

    private IEnumerator ShowLogo()
    {
        yield return new WaitForSeconds(LOGO_SECONDS);
        //hide logo
        logo.SetActive(false);
        
        ShowBook("SampleBookFlowchart");
    }

    private static void ShowBook(string bookName)
    {
        var obj = GameObject.Find(bookName);
        var ctl = obj.GetComponent<BookControl>();
        ctl.StartShowBook();
    }
}
