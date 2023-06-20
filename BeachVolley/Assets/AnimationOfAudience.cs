using UnityEngine;

public class AnimationOfAudience : MonoBehaviour
{
    private Animator DAnimator;
    private void Start()
    {
       DAnimator = GetComponent<Animator>();    
    }
    private void Update()
    {      
        if(GameManager.instance.score1 > 14 || GameManager.instance.score2 > 14)
        {
            DAnimator.SetTrigger("Celeb");
        }
    }
    
}
