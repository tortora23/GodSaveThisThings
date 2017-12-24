using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunnerBehavior : MonoBehaviour
{

    public bool isCaged = false;
    private Transform character;
    private Transform goal;
    private NavMeshAgent agent;
    private Rigidbody rb;
    private BoxCollider bx;
    private NavMeshAgent nva;

    // Use this for initialization
    void Start()
    {

        goal = GameObject.Find("Goal").transform;
        character = GetComponent<Transform>();
        gameObject.name = "Runner";
        agent = GetComponent<NavMeshAgent>();
        agent.SetDestination(goal.transform.position);
        rb = GetComponent<Rigidbody>();
        bx = GetComponent<BoxCollider>();
        nva = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {
        character.LookAt(goal.transform);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Equals("Cage") && !col.GetComponent<CageController>().isClose )
        {
           

            Debug.Log("collision with cage");
            isCaged = true;
            rb.Sleep();
            bx.enabled = false;
            nva.enabled = false;
            gameObject.transform.position = col.gameObject.transform.position;

        }
    }
    public void isFree()
    {
        isCaged = false;
        rb.WakeUp();
        bx.enabled = true;
        nva.enabled = true;
                
    }
}
