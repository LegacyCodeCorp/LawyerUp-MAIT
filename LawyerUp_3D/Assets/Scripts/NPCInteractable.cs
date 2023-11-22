
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCInteractable : MonoBehaviour{

    private Animator animator;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void Interact()
    {
        //ChatBubble3D.Create(transform.transform, new Vector3(-3f, 1.7f, 0f), ChatBubble3D.IconType.Happy, "I am Peasant");
        animator.SetTrigger("Walk");

    }
    

}

