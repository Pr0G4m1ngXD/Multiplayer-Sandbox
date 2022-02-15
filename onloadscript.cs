using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onloadscript : MonoBehaviour {
    // Start is called before the first frame update
    public GameObject sky, intel, gd;
    void Start() {
        int map = PlayerPrefs.GetInt("map");
        switch (map) {
            default:
            case 0:
                sky.SetActive(true);
                break;
            case 1:
                intel.SetActive(true);
                break;
            case 2:
                gd.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
