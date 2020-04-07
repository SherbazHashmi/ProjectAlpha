using UnityEngine;

public class isInteractableIcon : MonoBehaviour
{
    CanvasGroup canvasGroup;
    public bool isShown = false;
    // Start is called before the first frame update
    void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void show()
    {
        isShown = true;
        canvasGroup.alpha = 1;
    }

    public void hide()
    {
        isShown = false;
        canvasGroup.alpha = 0;
    }
}
