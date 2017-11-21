using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : VRAdapter
{

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
    }

    public override void OnPointerEnter()
    {
        base.OnPointerEnter();
        Debug.Log("on enter script"); 
    }
}
