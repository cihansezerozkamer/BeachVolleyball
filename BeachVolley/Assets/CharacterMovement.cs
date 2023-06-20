using UnityEngine;

public class CharacterMovement : MonoBehaviour
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

            inputY = Input.GetAxis("Horizontal");
            inputX = Input.GetAxis("Vertical");
        
        // Set the animator parameters for horizontal and vertical input
        animator.SetFloat("MoveX", inputX);
        animator.SetFloat("MoveY", inputY);

        if (inputX != 0 || inputY != 0)
        {
            PlaySandParticles();
        }
        else
        {
            StopSandParticles();
        }

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
