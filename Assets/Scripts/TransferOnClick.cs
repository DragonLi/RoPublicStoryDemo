using UnityEngine;
using UnityEngine.Assertions;

public class TransferOnClick : MonoBehaviour
{
    [SerializeField] private Fungus.Flowchart transferSource;
    [SerializeField] private Fungus.Flowchart transferTaget;

    private BookControl bookToGo;
    private BookControl bookToHide;

    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Assert.raiseExceptions = true;
        CheckResource();        
#endif
        bookToHide = transferSource.GetComponent<BookControl>();
        bookToGo = transferTaget.GetComponent<BookControl>();
    }

    private void CheckResource()
    {
        Assert.IsNotNull(transferSource);
        Assert.IsNotNull(transferTaget);
    }

    private void OnMouseDown()
    {
        if (!bookToGo.IsStarted())
        {
            bookToHide.Hide();
            bookToGo.StartShowBook();
        }
    }
}
