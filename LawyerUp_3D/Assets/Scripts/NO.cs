using JetBrains.Annotations;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;


public class ObjectDespawner : MonoBehaviour
{
   
    public float despawnTime = 3f;

    
    void Start()
    {
        // Invoke the Despawn method after despawnTime seconds
        Invoke("Despawn", despawnTime);
    }

    void Close()
    {
        
    }

    // Method to despawn the object
    void Despawn()
    {
        // Uncomment one of the following lines based on your preference:

        // Option 1: Deactivate the GameObject
        // gameObject.SetActive(false);

        // Option 2: Destroy the GameObject
        Destroy(gameObject);
       

        

        // You can also do other cleanup operations here before deactivating or destroying
    }
   
}
