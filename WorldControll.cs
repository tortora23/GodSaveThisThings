using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldControll : MonoBehaviour {

    public Transform[] bGSpawn;
    public Transform rSpawn;
    public int keys;
    public bool tRexFree = true;
    public float spawnTime;
    public float spawnTrex; //Debugging

    private GameObject badGuy;
    private GameObject runner;
    private GameObject tRex;

    private System.Random rnd = new System.Random();

    // Use this for initialization
    void Start () {

    
        badGuy = Resources.Load("BadGuy") as GameObject;
        runner = Resources.Load("Runner") as GameObject;
        tRex = Resources.Load("TRex") as GameObject;

        InvokeRepeating("spawnRunner", spawnTime, spawnTime); //Debugging
        InvokeRepeating("spawnBadGuy", spawnTime, spawnTime); //Debugging
        Invoke("spawnTRex", spawnTrex); //Debugging

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void spawnRunner()
    {
        Instantiate(runner, rSpawn.position, Quaternion.identity);
    }

    public void spawnBadGuy()
    {
        Instantiate(badGuy, bGSpawn[rnd.Next(bGSpawn.Length - 1)].position, Quaternion.identity);
    }

    public void spawnTRex(/*Vector3 position*/)
    {
        Instantiate(tRex, bGSpawn[rnd.Next(bGSpawn.Length - 1)].position, Quaternion.identity);
        tRexFree = false;
    }
    
    
}
