using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudienceCollide : MonoBehaviour
{
    public string triggerName = "Applause";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            // Trigger animation on each child's animator
            Animator[] childAnimators = GetComponentsInChildren<Animator>();
            foreach (Animator animator in childAnimators)
            {
                animator.SetTrigger(triggerName);
            }
        }
    }
}
