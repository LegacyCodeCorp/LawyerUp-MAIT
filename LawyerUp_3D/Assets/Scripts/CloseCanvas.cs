using UnityEngine;

public class CanvasPanelClo : MonoBehaviour
{
    public GameObject Panel;

    public void ClosePanel()
    {
       
            Panel.SetActive(false);
        
    }

}
