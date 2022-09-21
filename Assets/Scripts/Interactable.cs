using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public bool useEvents;
    [SerializeField]
    //message displayed to player when looking at an interactable
    public string promptMessage;


    public virtual string OnLook()
    {
        return promptMessage;
    }
    public void BaseInteract()
    {
        Interact();
    }
    protected virtual void Interact()
    {
        //no code here
        //template functaion to be overridden by our subclasses
    }

}