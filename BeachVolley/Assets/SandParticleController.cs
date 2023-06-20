using UnityEngine;

public class SandParticleController : MonoBehaviour
{
    public ParticleSystem sandParticles;

    private void Start()
    {
        // Reference the Particle System component
        sandParticles = GetComponentInChildren<ParticleSystem>();
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
