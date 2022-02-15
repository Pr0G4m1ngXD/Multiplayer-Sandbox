using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tntScript : MonoBehaviour {
    public Rigidbody thisrb;
    public GameObject disablethis;
    public GameObject enablethis;
    public GameObject delete;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        StartCoroutine(explode());
    }

    IEnumerator explode() {
        yield return new WaitForSeconds(5);
        thisrb.isKinematic = true;
        disablethis.SetActive(false);
        enablethis.SetActive(true);
        yield return new WaitForSeconds(3);
        delete.SetActive(false);
    }


}
