using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookScript : MonoBehaviour {

    public float mouseSensitivity = 300f;

    public Transform playerBody;
    public ToolManagerScript tms;
    public PlaceScript ps;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start() {
        Cursor.lockState = CursorLockMode.Locked;

    }

    // Update is called once per frame
    void Update() {
        float z = Input.GetAxis("Horizontal") * 4f;
        float x = Input.GetAxis("Vertical") * 2f;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        
        if(tms.toolScreen.activeInHierarchy || ps.itemScreen.activeInHierarchy) {
            Cursor.lockState = CursorLockMode.None;
        } else {
            Cursor.lockState = CursorLockMode.Locked;
            transform.localRotation = Quaternion.Euler(xRotation + x, 0f, z);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
