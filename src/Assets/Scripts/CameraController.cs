using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public GameObject player;		//Public variable to store a reference to the player game object

    // Original rotation of the camera in the movement scene
    private float originalXRotation;
    private float originalYRotation;

    // Camera movement smoothing factor
    private float cameraMovementSpeed = 0.25f;

    // Accelerometer readings used in previous valid camera movement operation
    private float previousAccelerationY;
    private float previousAccelerationX;

    // Last camera rotation axis values
    private float latestXRotation;
    private float latestYRotation;

    private Vector3 offset;			//Private variable to store the offset distance between the player and camera

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the player's position and camera's position.
        offset = transform.position - player.transform.position;
        originalXRotation = 90;
        originalYRotation = 0;
        previousAccelerationY = 0;
        previousAccelerationX = 0;
        latestXRotation = originalXRotation;
        latestYRotation = originalYRotation;
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {

        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player.transform.position + offset;

        // Calculate rotation along the x axis according to the accelerometer y value
        if (Mathf.Abs(previousAccelerationY - Input.acceleration.y) > 0.06)
        {
            previousAccelerationY = Input.acceleration.y;
            float xRotation = originalXRotation + (60 * -Input.acceleration.y) * cameraMovementSpeed;
            transform.rotation = Quaternion.Euler(xRotation, latestYRotation, 0.0f);
            latestXRotation = xRotation;
        }

        // Calculate rotation along the y axis according to the accelerometer x value
        if (Mathf.Abs(previousAccelerationX - Input.acceleration.x) > 0.06)
        {
            previousAccelerationX = Input.acceleration.x;
            float yRotation = originalYRotation + (60 * -Input.acceleration.x) * cameraMovementSpeed;
            transform.rotation = Quaternion.Euler(latestXRotation, yRotation, 0.0f);
            latestYRotation = yRotation;
        }
    }
}
