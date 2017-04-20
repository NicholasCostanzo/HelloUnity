using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 9.0f;
    public float sensitivityVert = 9.0f;
    
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;

    private float _pitch = 0;

    // Use this for initialization
    void Start() {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) 
            body.freezeRotation = true;
	}

	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
        }
        else if (axes == RotationAxes.MouseY) {
            _pitch -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _pitch = Mathf.Clamp(_pitch, minimumVert, maximumVert);

            float yaw = transform.localEulerAngles.y; //no horizontal rotation
            
            transform.localEulerAngles = new Vector3(_pitch, yaw, 0);
        }
        else {
            // both horizontal and vertical rotation here
            _pitch -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _pitch = Mathf.Clamp(_pitch, minimumVert, maximumVert);

            float deltaX = Input.GetAxis("Mouse X") * sensitivityHor;
            float yaw = transform.localEulerAngles.y + deltaX;

            transform.localEulerAngles = new Vector3(_pitch, yaw, 0);
        }
	}
}
