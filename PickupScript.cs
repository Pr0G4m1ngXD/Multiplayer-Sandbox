using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour {

    public Transform holdParent;
    private GameObject heldObj;
    public float moveForce = 250f;
    public float heldHoldVariable = 0.1f;
    public float pickUpRange = 15f;
    Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f); // center of the screen
    public static AudioClip pickup, place, throws;
    static AudioSource asrc;
    public bool pickupscriptenabled = true;
    public ToolManagerScript tms;
    public PlaceScript ps;

    private void Start() {
        pickup = Resources.Load<AudioClip>("pickup");
        place = Resources.Load<AudioClip>("place");
        throws = Resources.Load<AudioClip>("throw");
        asrc = GetComponent<AudioSource>();
    }


    void Update() {
        if (Input.GetMouseButtonDown(1) && pickupscriptenabled && !tms.toolScreen.activeInHierarchy && !ps.itemScreen.activeInHierarchy) {
            if (heldObj == null) {
                RaycastHit hit;
                Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

                if (Physics.Raycast(ray, out hit, pickUpRange)) {
                    PickUpObject(hit.transform.gameObject);
                    asrc.PlayOneShot(pickup);
                }
            } else {
                dropObject();
                asrc.PlayOneShot(place);
            }
        }
        if (Input.GetMouseButtonDown(0) && pickupscriptenabled && !tms.toolScreen.activeInHierarchy && !ps.itemScreen.activeInHierarchy) {
            if (heldObj == null) {
                RaycastHit hit;
                Ray ray = Camera.main.ViewportPointToRay(rayOrigin);

                if (Physics.Raycast(ray, out hit, pickUpRange)) {
                    var pickObj = hit.transform.gameObject;
                    if (pickObj.GetComponent<Rigidbody>()) {
                        Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
                        objRig.useGravity = false;
                        objRig.drag = 10f;

                        objRig.transform.parent = holdParent;
                        heldObj = pickObj;
                        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
                        heldRig.useGravity = true;
                        heldRig.drag = 1f;
                        heldRig.AddForce(Camera.main.transform.forward * 2500f);
                        heldObj.transform.parent = null;
                        heldObj = null;
                        asrc.PlayOneShot(throws);
                    }
                }
            } else {
                ThrowObject();
                asrc.PlayOneShot(throws);
            }
        }

        if (heldObj != null && pickupscriptenabled) {
            MoveObject();
        }
        if (heldObj != null && !pickupscriptenabled) {
            dropObject();
            asrc.PlayOneShot(place);
        }
    }

    void MoveObject() {
        if (Vector3.Distance(heldObj.transform.position, holdParent.position) > heldHoldVariable) {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            Rigidbody heldObjRigid = heldObj.GetComponent<Rigidbody>();
            heldObjRigid.AddForce(moveDirection * moveForce);
        }
    }
    void ThrowObject() {
        
           
            
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1f;
        heldRig.AddForce(Camera.main.transform.forward * 2500f);

        heldObj.transform.parent = null;
        heldObj = null;

    }

    void PickUpObject(GameObject pickObj) {

        if (pickObj.GetComponent<Rigidbody>()) {
            Rigidbody objRig = pickObj.GetComponent<Rigidbody>();
            objRig.useGravity = false;
            objRig.drag = 10f;

            objRig.transform.parent = holdParent;
            heldObj = pickObj;
        }
    }

    public void dropObject() {
        Rigidbody heldRig = heldObj.GetComponent<Rigidbody>();
        heldRig.useGravity = true;
        heldRig.drag = 1f;


        heldObj.transform.parent = null;
        heldObj = null;

    }

    
}
