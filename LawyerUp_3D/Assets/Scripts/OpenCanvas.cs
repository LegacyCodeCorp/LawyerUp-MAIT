using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class CanvasPanelOpener : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if(Panel!= null)
        {
            Panel.SetActive(true);
        }
    }
   

}
