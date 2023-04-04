using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float playerSpeed = 2f;
    public CharacterController CharacterController;
    public bool playerFollows = false;
    public Transform orientation;
    Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        CharacterController= GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(xInput, 0, yInput);
        moveDir = orientation.forward * yInput + orientation.right * xInput;
        if (move != Vector3.zero)
        {
            CharacterController.Move(moveDir * Time.deltaTime *playerSpeed);
        }

    }
    
    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.CompareTag("enemy") && !playerFollows)
    //    {
    //        playerFollows = true;

    //    }
    //}
}
