using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CageController : MonoBehaviour {

    public bool isClose = false;

    private GameObject prisoner;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name.Equals("Runner") && !isClose )
        {
            prisoner = col.gameObject;
            Debug.Log("collision with runner");
            isClose = true;

            NavMeshObstacle obstacle = gameObject.AddComponent<NavMeshObstacle>();
            obstacle.size = new Vector3(1.2f, 1.2f, 1.2f );
            transform.parent.GetComponent<BadGuyBehavior>().state = 4;
        }
    }

    public void open()
    {
        prisoner.GetComponent<RunnerBehavior>().isFree();
        Destroy(gameObject);
    }
}

