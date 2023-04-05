using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController CharacterController;
    public bool playerFollows = false;
    public Transform orientation;

    private float playerSpeed = 5f;
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
    public void setSpeed(float speed)
    {
        playerSpeed = speed;
    }


}
