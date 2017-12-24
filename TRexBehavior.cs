using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TRexBehavior : MonoBehaviour {

    private WorldControll wc ;
    private NavMeshAgent agent;
    private Transform character;
    private GameObject[] gos;
    private GameObject target;
    private float distance;

	// Use this for initialization
	void Start () {

        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Transform>();
        wc = GameObject.Find("EventSystem").GetComponent<WorldControll>();
        Invoke("death", 20);

	}
	
	// Update is called once per frame
	void Update ()
    {
        distance = Mathf.Infinity;
        gos = GameObject.FindGameObjectsWithTag("BadGuy");
        foreach (GameObject go in gos)
        {
            float dist = Vector3.Distance(character.position, go.transform.position);
            if (distance > dist )
            {
                target = go;
                distance = dist;
            }
        }

        agent.destination = target.transform.position;
        character.LookAt(target.transform);

        if (distance < 1.3f)
        {
            Destroy(target);
        }
    }

    private void death()
    {
        wc.tRexFree = true;
        Destroy(gameObject);
    }
}
