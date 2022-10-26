using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    public AudioSource audioSource;
  
    
    
    void update()
    {
        audioSource.Play();
    }
}
