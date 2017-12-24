using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuyBehavior : MonoBehaviour {
    
    public int state;   //1 insegue
                        //2 infastidisce
                        //3 cade
                        //4 ingabbia
                        //5 spinto

    private NavMeshAgent agent;
    private Transform character;
    private GameObject[] gos;
    private GameObject target;

    float distance;

	// Use this for initialization
	void Start () {

        state = 1;
        agent = GetComponent<NavMeshAgent>();
        character = GetComponent<Transform>();
        character.name = "BadGuy";
	}
	
	// Update is called once per frame
	void Update () {

        switch (state)
        {
            case 1:

                distance = Mathf.Infinity;
                gos = GameObject.FindGameObjectsWithTag("Runner");
                foreach (GameObject go in gos)
                {
                    float dist = Vector3.Distance(character.position, go.transform.position);
                    if(distance > dist && !go.GetComponent<RunnerBehavior>().isCaged)
                    {
                        target = go;
                        distance = dist;
                    }
                }

                    agent.destination = target.transform.position;
                    character.LookAt(target.transform);
                


                break;

            case 2:

                Destroy(gameObject);
                break;

            case 4:

                character.DetachChildren();
                state = 2;

                break;
        }

	}
    

}
