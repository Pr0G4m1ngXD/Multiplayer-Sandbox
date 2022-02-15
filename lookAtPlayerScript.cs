using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayerScript : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        Vector3 forward = Camera.main.transform.forward;
        forward.y = 0f;
        transform.rotation = Quaternion.LookRotation(forward);
    }
}
