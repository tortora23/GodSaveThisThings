using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControl : MonoBehaviour {

    public float spawnTimeTr;

    private WorldControll wc;

	// Use this for initialization
	void Start () {

        wc = GameObject.Find("EventSystem").GetComponent<WorldControll>();

	}
	
	// Update is called once per frame
	void Update () {


        if (Input.touchCount == 1)
        {

            if (Input.GetTouch(0).phase == TouchPhase.Stationary)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name.Equals("Terrain"))
                    {
                        spawnTimeTr -= Time.deltaTime;
                        if (spawnTimeTr < 0 && wc.tRexFree)
                        {
                            wc.spawnTRex(/*Input.GetTouch(0).position*/);
                        } 
                    }
                    else if (hit.collider.name.Equals("BadGuy"))
                    {
                        //pick it and follow touch

                    }else if (hit.collider.name.Equals("Cage") && hit.collider.gameObject.GetComponent<CageController>().isClose)
                    {
                        if (wc.keys > 0)
                        {
                            hit.collider.GetComponent<CageController>().open();
                            wc.keys -= 1;
                        }
                        else
                        {
                            //say nooooo
                        }
                    }

                }

            }
            else if (Input.GetTouch(0).phase == TouchPhase.Moved)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.name.Equals("Terrain"))
                    {
                        //cast tornado
                    }
                }
            }
        }
        else if(true)
        {
        
        }
		
	}
}
