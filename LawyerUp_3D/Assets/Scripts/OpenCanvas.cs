using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject panel;

    void Start()
    {
        // Ensure the panel is initially hidden
        panel.SetActive(false);
    }

    public void TogglePanel()
    {
        // Toggle the active state of the panel when the button is pressed
        panel.SetActive(!panel.activeSelf);
    }
}