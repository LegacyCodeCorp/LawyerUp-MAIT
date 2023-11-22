using UnityEngine;

public class NumberGenerator : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log(Random.Range(0, 10));
    } 
    
}
