using SMI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SMIPlatform : GazeMonoBehaviour
{
    private VRAdapter adapter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void OnGazeEnter(RaycastHit hitInformation)
    {
        base.OnGazeEnter(hitInformation);
        if (adapter != null)
        {
            adapter.OnPointerEnter();
        }
    }

    public override void OnGazeExit()
    {
        base.OnGazeExit();
        if (adapter != null)
        {
            adapter.OnPointerExit();
        }
    }

    public override void OnGazeStay(RaycastHit hitInformation)
    {
        base.OnGazeStay(hitInformation);
        if (adapter != null)
        {
            adapter.OnPointerStay(hitInformation);
        }
    }

    public void setAdapter(VRAdapter adapter)
    {
        this.adapter = adapter;
    }
}
