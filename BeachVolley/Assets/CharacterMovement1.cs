using UnityEngine;

public class CharacterMovement1 : MonoBehaviour
{
    private Animator animator;
    private float inputX;
    private float inputY;
    private const float transitionDuration = 0.2f; // Adjust this value for the desired transition speed
    public ParticleSystem sandParticles;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Get the horizontal and vertical input axis values

            inputY = Input.GetAxis("Horizontal2");
            inputX = Input.GetAxis("Vertical2");
        
        if(inputX != 0 || inputY != 0)
        {
            PlaySandParticles();
        }
        else
        {
            StopSandParticles();
        }
        // Set the animator parameters for horizontal and vertical input
        animator.SetFloat("MoveX", inputX);
        animator.SetFloat("MoveY", inputY);
    }
   

   

    private void PlaySandParticles()
    {
        // Play the sand particle effect
        sandParticles.Play();
    }

    private void StopSandParticles()
    {
        // Stop the sand particle effect
        sandParticles.Stop();
    }
}
