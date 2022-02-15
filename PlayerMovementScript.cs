using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class PlayerMovementScript : MonoBehaviour {
    public CharacterController controller;
    public Transform groundCheck;

    public GameObject localcam;

    public float speed = 8f;
    private float state;
    public float gravity = -10f;
    public float groundDist = 0.4f;
    public float jumpHeight = 2f;
    public ToolManagerScript tms;
    public PlaceScript ps;
    public GameObject tmsgo;

    public LayerMask groundMask;

    Vector3 velocity;
    bool onGround;

    public void SuperSpeed() {
        speed = 20f;
    }

    // Start is called before the first frame update
    void Start() {
        tms = tmsgo.GetComponent<ToolManagerScript>();

        
    }

    // Update is called once per frame
    void Update() {
        onGround = Physics.CheckSphere(groundCheck.position, groundDist, groundMask);

        if (onGround && velocity.y < 0) {
            velocity.y = -2f;
        }
        if (Input.GetKey(KeyCode.LeftControl) && !tms.toolScreen.activeInHierarchy && !ps.itemScreen.activeInHierarchy) {
            speed = 12f;
            state += 0.1f;
            state = Mathf.Clamp(state, 0f, 1f);

        } else {
            speed = 8f;
           state -= 0.1f;
            state = Mathf.Clamp(state, 0f, 1f);
        }
        //Camera.main.fieldOfView = Mathf.Lerp(60f, 65f, state);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        if (!tms.toolScreen.activeInHierarchy && !ps.itemScreen.activeInHierarchy) {
            controller.Move(move * speed * Time.deltaTime);
            
            if(Input.GetKeyDown(KeyCode.R) || transform.position.y < -25f) {
                Debug.Log("amhere");
                CharacterController cc = GetComponent<CharacterController>();
                
                cc.enabled = false;
                cc.transform.position = new Vector3(0f, 5f, 0f);
                cc.enabled = true;
                
            }
        }
        if (Input.GetButton("Jump") && onGround && !tms.toolScreen.activeInHierarchy && !ps.itemScreen.activeInHierarchy) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        


    }

    public float pushPower = 2.0F;

    

    void OnControllerColliderHit(ControllerColliderHit hit) {

   


        Rigidbody body = hit.collider.attachedRigidbody;
        
        // no rigidbody
        if (body == null || body.isKinematic)
            return;

        // We dont want to push objects below us
        if (hit.moveDirection.y < -0.3f)
            return;

        // Calculate push direction from move direction,
        // we only push objects to the sides never up and down
        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        // If you know how fast your character is trying to move,
        // then you can also multiply the push velocity by that.

        // Apply the push
        body.velocity = pushDir * pushPower;


       
    }

    
}
