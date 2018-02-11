using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, GazeInterface
{
    public Platform platform = Platform.Generic;
    private VRAdapter adapter;

	// Use this for initialization
	void Start () {

        Debug.Log("Working Test");

        // TODO: could be inside the interface
        gameObject.AddComponent<VRAdapter>();
        adapter = gameObject.GetComponent<VRAdapter>();
        adapter.setTarget(this.gameObject);
        adapter.setPlatform(platform);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnPointerEnter()
    {
        Debug.Log("Change colour to green");
        gameObject.GetComponent<Renderer>().material.color = Color.green;
    }

    public void OnPointerExit()
    {
        Debug.Log("Change colour to red");
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void OnPointerStay(RaycastHit hitInformation)
    {
        
    }

    
}
