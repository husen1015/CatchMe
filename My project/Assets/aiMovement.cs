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
    int enemyFollows = 1;
    bool canBeUsed = true;
    // Start is called before the first frame update
    void Start()
    {
        CharacterController = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyFollows == 1)
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

    void OnTriggerEnter(Collider other)
    {
        if (canBeUsed && other.CompareTag("Player"))
        {
            enemyFollows = Mathf.Abs(enemyFollows - 1);
            Debug.Log("collided");
            canBeUsed = false;
            StartCoroutine(coolDown());
        }
    }

    IEnumerator coolDown()
    {
        yield return new WaitForSeconds(2);
        canBeUsed = true;
    }
}