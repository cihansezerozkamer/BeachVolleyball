using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Vector3 offset1;
    public Vector3 win;
    public Vector3 smoothedPosition;
    public bool isWon = false;
    public float rotationSpeed = 10f; // The speed of rotation

    private bool hasReachedWinOffset = false;
    private void Start()
    {
        offset1 = offset;
    }
    void LateUpdate()
    {
        if (!isWon)
        {
            CameraRotate();
        }
        else
        {
            if (!hasReachedWinOffset)
            {
                // Translate camera to the win position
                Vector3 desiredPosition = win;
                smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.01f);
                transform.position = smoothedPosition;

                if (Vector3.Distance(transform.position, win) < 0.01f)
                {
                    hasReachedWinOffset = true;
                }
            }
            else
            {
                CameraTurnAround();
            }
        }

        transform.LookAt(target);
    }

    void CameraRotate()
    {
        Vector3 desiredPosition = target.position + offset;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }

    void CameraTurnAround()
    {
        float rotationAmount = rotationSpeed * Time.deltaTime;
        transform.RotateAround(target.position, Vector3.up, rotationAmount);
    }
    public void ResetOffset()
    {
        isWon = false;
        offset = offset1;
        hasReachedWinOffset=false;
    }
}
