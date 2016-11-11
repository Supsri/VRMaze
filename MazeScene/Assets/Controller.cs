using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

    public GameObject ground;

    private bool walking = false;
    private Vector3 spawnPoint;

	// Use this for initialization
	void Start () {

        spawnPoint = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (walking)
        {
            transform.position = transform.position + Camera.main.transform.forward * .5f * Time.deltaTime;
        }

        if(transform.position.y < -20f)
        {
            transform.position = spawnPoint;
        }
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f,0.5f,0));

            RaycastHit hit;

            if(Physics.Raycast(ray,out hit))
            {
                if (hit.collider.name.Contains("plane"))
                {
                    walking = false;
                }

                else
                {
                    walking = true;
                }
            }
        
	}
}
