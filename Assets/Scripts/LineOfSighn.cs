using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSighn : MonoBehaviour
{

    public Animator animator;

    public float mRaycastRadius;  // width of our line of sight (x-axis and y-axis)
    public float mTargetDetectionDistance;  // depth of our line of sight (z-axis)

    private RaycastHit _mHitInfo;   // allocating memory for the raycasthit
    // to avoid Garbage
    private bool _bHasDetectedEnnemy = false;   // tracking whether the player
    // is detected to change color in gizmos

    public void CheckForTargetInLineOfSight()
    {
        _bHasDetectedEnnemy = Physics.SphereCast(transform.position, mRaycastRadius, transform.forward, out _mHitInfo, mTargetDetectionDistance);

        if (_bHasDetectedEnnemy)
        {
            if (_mHitInfo.transform.CompareTag("Player"))
            {
                Debug.Log("Detected Player");
                //get animator attacted to game object
                animator = gameObject.GetComponent<Animator>();
                animator.SetBool("PlayRun", true);
                // insert fighting logic here
            }
            else
            {
                Debug.Log("No Player detected");
                // no player detected, insert your own logic
            }

        }
        else
        {
            // no player detected, insert your own logic
        }

    }
}

    

