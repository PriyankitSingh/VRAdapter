using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SMI;

/**
 * Defines the type of platform for which the script is being written.
 * Generic means non eye tracking. Its uses the middle of the screen
 * as a selector.
 * */
public enum Platform
{
    FOVE, SMIVive, Generic
}
public class VRAdapter : MonoBehaviour {
    public Platform targetPlatform;

    private GazeInterface targetScript;
    private SMIPlatform smi;

    // Use this for initialization 
    void Start()
    {
        // get the type of main camera 
        // this is used to check which type of platform we have 

        gameObject.AddComponent<SMIPlatform>();
        SMIPlatform smi = gameObject.GetComponent<SMIPlatform>();

        smi.setAdapter(this);
    }

    public void setTarget(GazeInterface targetScript)
    {
        this.targetScript = targetScript;
    }

    public void OnPointerEnter() {
        targetScript.OnPointerEnter();
    }

    public void OnPointerExit() {
        targetScript.OnPointerExit();
    }

    public void OnPointerStay(RaycastHit hitInformation) {
        targetScript.OnPointerStay(hitInformation);
    }

}
