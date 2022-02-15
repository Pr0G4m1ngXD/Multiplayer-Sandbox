using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class creategamescript : MonoBehaviour {
    // Start is called before the first frame update

    public TMP_Dropdown map;
    void Start() {
        PlayerPrefs.SetInt("map", 0);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void clickjoin() {
        int dropchoice = map.value;
        PlayerPrefs.SetInt("map", dropchoice);
        SceneManager.LoadScene(1);
    }
}
