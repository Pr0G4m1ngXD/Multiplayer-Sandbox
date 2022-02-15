using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToolManagerScript : MonoBehaviour {

    public TMP_Text title;
    public TMP_Text description;

    public PickupScript pus;
    public PlaceScript ps;

    public GameObject toolScreen;
    

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Alpha1) && !ps.itemScreen.activeInHierarchy) {
            changeTool("Gravity Gun", "Use it to grab, place and throw objects", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && !ps.itemScreen.activeInHierarchy) {
            changeTool("Add/Remove Objects", "Place object from your Inventory", 2);
        }
        if (Input.GetKeyDown(KeyCode.G) && !ps.itemScreen.activeInHierarchy) {
            toolScreen.SetActive(!toolScreen.activeInHierarchy);
        }
    }

    public void changeToolTo1() {
        changeTool("Gravity Gun", "Use it to grab, place and throw objects", 1);
    }
    public void changeToolTo2() {
        changeTool("Add/Remove Objects", "Place object from your Inventory", 2);
    }
    public void changeToolTo3() {
        changeTool("Place/Destroy Objects", "Place object from your Inventory", 2);
    }

    public void changeTool(string name, string desc, int tool) {
        title.text = name;
        description.text = desc;
        

        switch (tool) {
            case 1:
                pus.pickupscriptenabled = true;
                ps.placescriptenabled = false;
                break;
            case 2:
                pus.pickupscriptenabled = false;
                ps.placescriptenabled = true;
                break;
            default:
                Debug.LogError("SOME SHIT GONE WRONG");
                pus.pickupscriptenabled = true;
                ps.placescriptenabled = false;
                break;
        }
    }
}
