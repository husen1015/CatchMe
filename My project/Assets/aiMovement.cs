using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
public class aiMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject playerParent;

    CharacterController CharacterController;
    Animator animator;
    float speed = 2f;
    int enemyFollows = 1;
    bool canBeUsed = true;
    bool shouldWait = false;
    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyFollows == 1 && !shouldWait)
            followPlayer();
        
        else if (enemyFollows == 1 && shouldWait)
            CharacterController.Move(new Vector3(0, 0, 0));

        else if (enemyFollows == 0)
            runAway();  
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

    void OnTriggerEnter(Collider other)
    {
        if (canBeUsed && other.CompareTag("Player"))
        {

            enemyFollows = Mathf.Abs(enemyFollows - 1);
            animator.SetInteger("nearr", 1);
            Debug.Log("collided");
            canBeUsed = false;
            StartCoroutine(coolDown());
            if (enemyFollows == 1)
            {
                shouldWait = true;
                StartCoroutine(wait());

                playerParent.GetComponent<movement>().setSpeed(3f);
                speed = 4f;
            }
            else
            {
                playerParent.GetComponent<movement>().setSpeed(4f);
                speed = 3f;
            }
        }
    }

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(2);
        canBeUsed = true;
    }
    IEnumerator wait()
    {
        Debug.Log("now stopping");

        yield return new WaitForSeconds(2);
        shouldWait= false;
    }
}