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
    private GameObject targetObject;
    private SMIPlatform smi;
    private HeadTrackingPlatform headTracker;
    private GameObject[] mainCameras;
    private GameObject cam;

    // Use this for initialization 
    void Start()
    {
        // get the type of main camera 
        // this is used to check which type of platform we have 
        if(targetPlatform == Platform.SMIVive)
        {
            gameObject.AddComponent<SMIPlatform>();
            SMIPlatform smi = gameObject.GetComponent<SMIPlatform>();
            smi.setAdapter(this);
        } else if(targetPlatform == Platform.Generic)
        {
            mainCameras = GameObject.FindGameObjectsWithTag("MainCamera");
            Debug.Log(mainCameras[0].name);
            for (int i = 0; i < mainCameras.Length; i++)
            {
                if (mainCameras[i].name == "Camera (eye)")
                {
                    Debug.Log("index: " + i);
                    cam = mainCameras[i];
                    // set up here
                    Debug.Log("camera found");
                    cam.AddComponent<HeadTrackingPlatform>();
                    headTracker = cam.GetComponent<HeadTrackingPlatform>();
                    headTracker.setAdapter(this);
                    headTracker.setTarget(targetObject);
                    break;
                }
            }
        }
    }

    public void setTarget(GameObject target)
    {
        this.targetScript = gameObject.GetComponent<GazeInterface>();
        this.targetObject = target;
    }

    public void setPlatform(Platform platform)
    {
        this.targetPlatform = platform;
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
