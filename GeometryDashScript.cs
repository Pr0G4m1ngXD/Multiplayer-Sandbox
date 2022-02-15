using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometryDashScript : MonoBehaviour {
    Rigidbody rg;
    // Start is called before the first frame update
    void Start() {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() {
        System.Random rnd = new System.Random();
        int rng = rnd.Next(1, 200);
        transform.localPosition += new Vector3(0, 0, 3f * Time.deltaTime);
        if(rng == 1) {
            Vector3 jump = new Vector3(0f, 100f, 0f);
            rg.AddForce(jump);
        }
    }
}
