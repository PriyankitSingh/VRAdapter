using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadTrackingPlatform : MonoBehaviour {
    public float distance = 100f;
    public GameObject selectedObject;

    private VRAdapter adapter;
    private bool hasEntered = false;
    private GameObject target;

    private void FixedUpdate()
    {
        RaycastHit seen;
        Ray rayDirection = new Ray(transform.position, transform.forward);
        if(Physics.Raycast(rayDirection, out seen, distance))
        {
            selectedObject = seen.transform.gameObject;
            // Are we looking at the target
            if (selectedObject.Equals(target))
            {
                if (hasEntered)
                {
                    adapter.OnPointerStay(seen);
                }
                else // if we're seeing the object for the first time
                {
                    adapter.OnPointerEnter();
                }
            } else if (hasEntered) // not looking at the object anymore
            {
                adapter.OnPointerExit();
                hasEntered = false;
            }
        }

    }

    

    public void setAdapter(VRAdapter adapter)
    {
        this.adapter = adapter;
    }

    public void setTarget(GameObject target)
    {
        this.target = target;
    }
}
