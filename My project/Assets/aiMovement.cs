using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
public class aiMovement : MonoBehaviour
{
    public float speed = 2f;
    public CharacterController CharacterController;
    public GameObject player;
    public GameObject playerParent;
    bool enemyFollows;
    // Start is called before the first frame update
    void Start()
    {
        CharacterController= GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!playerParent.GetComponent<movement>().playerFollows)
        {
            followPlayer();
        }
        else
        {
            runAway();
        }
    }
    void followPlayer()
    {
        transform.LookAt(player.transform);
        Vector3 dir = player.transform.position - transform.position;
        dir = dir.normalized;

        CharacterController.Move(dir * Time.deltaTime * speed);
    }
    void runAway()
    {
        transform.LookAt(player.transform);
        Vector3 dir = player.transform.position - transform.position;
        dir = dir.normalized;
        dir *= -1;

        CharacterController.Move(dir * Time.deltaTime * speed);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Player") && !enemyFollows)
    //    {
    //        player.GetComponent<movement>().playerFollows = false;
    //        enemyFollows = true;
    //    }
    //}
}
