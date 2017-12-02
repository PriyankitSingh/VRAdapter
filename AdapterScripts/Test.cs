using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour, GazeInterface
{
    private VRAdapter adapter;
	// Use this for initialization
	void Start () {
        // TODO: could be inside the interface
        gameObject.AddComponent<VRAdapter>();
        adapter = gameObject.GetComponent<VRAdapter>();
        adapter.setTarget(this.gameObject);
        adapter.setPlatform(Platform.Generic);
    }
	
	// Update is called once per frame
	void Update () {
        
    }

    public void OnPointerEnter()
    {
        Debug.Log("pointer enter in test");
    }

    public void OnPointerExit()
    {
        Debug.Log("pointer exit in test");
    }

    public void OnPointerStay(RaycastHit hitInformation)
    {
        
    }

    
}
