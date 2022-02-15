using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlaceScript : MonoBehaviour {

    public Transform placeHere;
    public TMP_Text number;
    public GameObject wrongcube, glasscube, woozybox, sphere, yourewinner;
    public GameObject tnt, bigshot, geometrydash, bonzibuddy, ifone;
    public GameObject spoon, airpod, chair, fnfspeaker, note7;
    public Sprite noneS, wrongcubeS, glasscubeS, woozyboxS, sphereS, yourewinnerS, tntS, bigshotS, geometrydashS, bonzibuddyS, ifoneS, spoonS, airpodS, chairS, fnfspeakerS, note7S;
    public AudioClip place2;
    static AudioSource audiop;
    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
    public int selelcted = 1;

    public bool placescriptenabled = false;
    public ToolManagerScript tms;
    public GameObject itemScreen;
    public Image topslot, mainslot, bottomslot;
    // Start is called before the first frame update
    void Start() {
        place2 = Resources.Load<AudioClip>("create");
        audiop = GetComponent<AudioSource>();

        noneS = Resources.Load<Sprite>("none");
        wrongcubeS = Resources.Load<Sprite>("wrongcube");
        glasscubeS = Resources.Load<Sprite>("glasscube");
        woozyboxS = Resources.Load<Sprite>("woozy");
        sphereS = Resources.Load<Sprite>("sphere");
        yourewinnerS = Resources.Load<Sprite>("yourewinner");
        tntS = Resources.Load<Sprite>("tnt");
        bigshotS = Resources.Load<Sprite>("bigshot");
        geometrydashS = Resources.Load<Sprite>("player");
        bonzibuddyS = Resources.Load<Sprite>("bonzibuddy");
        ifoneS = Resources.Load<Sprite>("ifone");
        spoonS = Resources.Load<Sprite>("chair");
        airpodS = Resources.Load<Sprite>("airpod");
        chairS = Resources.Load<Sprite>("chair");
        fnfspeakerS = Resources.Load<Sprite>("fnf");
        note7S = Resources.Load<Sprite>("note7");

    }
    public void item1() { selelcted = 1; }
    public void item2() { selelcted = 2; }
    public void item3() { selelcted = 3; }
    public void item4() { selelcted = 4; }
    public void item5() { selelcted = 5; }
    public void item6() { selelcted = 6; }
    public void item7() { selelcted = 7; }
    public void item8() { selelcted = 8; }
    public void item9() { selelcted = 9; }
    public void item10() { selelcted = 10; }
    public void item11() { selelcted = 11; }
    public void item12() { selelcted = 12; }
    public void item13() { selelcted = 13; }
    public void item14() { selelcted = 14; }
    public void item15() { selelcted = 15; }

    // Update is called once per frame
    void Update() {

        if (Input.GetAxis("Mouse ScrollWheel") > 0f) { // forward
            selelcted--;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) { // backwards
            selelcted++;
        }
        if (Input.GetKeyDown(KeyCode.E) && !tms.toolScreen.activeInHierarchy) {
            itemScreen.SetActive(!itemScreen.activeInHierarchy);
        }

        selelcted = Mathf.Clamp(selelcted, 1, 15);

        switch (selelcted) {
            default:
            case 1:
                topslot.sprite = noneS;
                mainslot.sprite = wrongcubeS;
                bottomslot.sprite = glasscubeS;
                break;
            case 2:
                topslot.sprite = wrongcubeS;
                mainslot.sprite = glasscubeS;
                bottomslot.sprite = woozyboxS;
                break;
            case 3:
                topslot.sprite = glasscubeS;
                mainslot.sprite = woozyboxS;
                bottomslot.sprite = sphereS;
                break;
            case 4:
                topslot.sprite = woozyboxS;
                mainslot.sprite = sphereS;
                bottomslot.sprite = yourewinnerS;
                break;
            case 5:
                topslot.sprite = sphereS;
                mainslot.sprite = yourewinnerS;
                bottomslot.sprite = tntS;
                break;
            case 6:
                topslot.sprite = yourewinnerS;
                mainslot.sprite = tntS;
                bottomslot.sprite = bigshotS;
                break;
            case 7:
                topslot.sprite = tntS;
                mainslot.sprite = bigshotS;
                bottomslot.sprite = geometrydashS;
                break;
            case 8:
                topslot.sprite = bigshotS;
                mainslot.sprite = geometrydashS;
                bottomslot.sprite = bonzibuddyS;
                break;
            case 9:
                topslot.sprite = geometrydashS;
                mainslot.sprite = bonzibuddyS;
                bottomslot.sprite = ifoneS;
                break;
            case 10:
                topslot.sprite = bonzibuddyS;
                mainslot.sprite = ifoneS;
                bottomslot.sprite = spoonS;
                break;
            case 11:
                topslot.sprite = ifoneS;
                mainslot.sprite = spoonS;
                bottomslot.sprite = airpodS;
                break;
            case 12:
                topslot.sprite = spoonS;
                mainslot.sprite = airpodS;
                bottomslot.sprite = chairS;
                break;
            case 13:
                topslot.sprite = airpodS;
                mainslot.sprite = chairS;
                bottomslot.sprite = fnfspeakerS;
                break;
            case 14:
                topslot.sprite = chairS;
                mainslot.sprite = fnfspeakerS;
                bottomslot.sprite = note7S;
                break;
            case 15:
                topslot.sprite = fnfspeakerS;
                mainslot.sprite = note7S;
                bottomslot.sprite = noneS;
                break;

        }

        number.text = selelcted.ToString();

        if (Input.GetMouseButtonDown(0) && placescriptenabled && !tms.toolScreen.activeInHierarchy && !itemScreen.activeInHierarchy) {
            GameObject obj;
            switch (selelcted) {
                default:
                case 1:
                    obj = Instantiate(wrongcube, placeHere);
                    break;
                case 2:
                    obj = Instantiate(glasscube, placeHere);
                    break;
                case 3:
                    obj = Instantiate(woozybox, placeHere);
                    break;
                case 4:
                    obj = Instantiate(sphere, placeHere);
                    break;
                case 5:
                    obj = Instantiate(yourewinner, placeHere);
                    break;
                case 6:
                    obj = Instantiate(tnt, placeHere);
                    break;
                case 7:
                    obj = Instantiate(bigshot, placeHere);
                    break;
                case 8:
                    obj = Instantiate(geometrydash, placeHere);
                    break;
                case 9:
                    obj = Instantiate(bonzibuddy, placeHere);
                    break;
                case 10:
                    obj = Instantiate(ifone, placeHere);
                    break;
                case 11:
                    obj = Instantiate(spoon, placeHere);
                    break;
                case 12:
                    obj = Instantiate(airpod, placeHere);
                    break;
                case 13:
                    obj = Instantiate(chair, placeHere);
                    break;
                case 14:
                    obj = Instantiate(fnfspeaker, placeHere);
                    break;
                case 15:
                    obj = Instantiate(note7, placeHere);
                    break;

            }

            obj.SetActive(true);
            obj.transform.parent = null;

            audiop.PlayOneShot(place2);


        }
        if (Input.GetMouseButtonDown(1) && placescriptenabled && !tms.toolScreen.activeInHierarchy && !itemScreen.activeInHierarchy) {
            RaycastHit hit;
            Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
            if (Physics.Raycast(ray, out hit, 20f)) {
                if (hit.transform.gameObject.GetComponent<Rigidbody>()) {
                    hit.transform.gameObject.SetActive(false);
                    audiop.PlayOneShot(place2);
                }

            }
        }
    }
}
