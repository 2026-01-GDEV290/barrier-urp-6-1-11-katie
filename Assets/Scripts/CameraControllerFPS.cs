using UnityEngine;

public class CameraControllerFPS : MonoBehaviour
{
    public float sensitivity = 2f;
    private float xRotation = 0f;
    private float yRotation = 0f;
    
    void Start()
    {
        //Lock and hide the mouse cursor from the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Camera picks up on mouse position
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -360f, 360f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.parent.Rotate(Vector3.up * mouseX);
    }
}