using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] private float rotationAngle = 90f; // How far the camera rotates
    [SerializeField] private float rotationSpeed = 5f; // Speed of rotation

    private Quaternion startRotation;  // Initial rotation
    private Quaternion targetRotation; // Target rotation
    private bool isRotating = false;   // Prevent multiple rotations

    void Start()
    {
        startRotation = transform.rotation;
        targetRotation = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + rotationAngle, transform.eulerAngles.z);
    }

    void Update()
    {
        if (!isRotating)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                StartCoroutine(RotateCamera(targetRotation));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(RotateCamera(startRotation));
            }
        }
    }

    private System.Collections.IEnumerator RotateCamera(Quaternion target)
    {
        isRotating = true;
        float timeElapsed = 0f;
        Quaternion initialRotation = transform.rotation;

        while (timeElapsed < 1f)
        {
            transform.rotation = Quaternion.Slerp(initialRotation, target, timeElapsed);
            timeElapsed += Time.deltaTime * rotationSpeed;
            yield return null;
        }

        transform.rotation = target;
        isRotating = false;
    }
}
