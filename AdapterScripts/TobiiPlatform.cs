using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tobii.Gaming.Internal;


namespace Tobii.Gaming
{
    /// <summary>
    /// Component that makes the game object GazeAware, meaning aware if the 
    /// user's eye-gaze is on it or not.
    /// </summary>
    
    public class TobiiPlatform : MonoBehaviour
    {
        private GazeAware _gazeAware;
        private VRAdapter adapter;
        private bool hasEntered = false;

        void Start()
        {
            Debug.Log("Working TobiiPlatform");
            gameObject.AddComponent<GazeAware>();
            _gazeAware = gameObject.GetComponent<GazeAware>();
        }

        void Update()
        {
            Debug.Log("gazeAware HasGazeFocus is" + _gazeAware.HasGazeFocus);

            if (_gazeAware.HasGazeFocus) // Looking at the object
            {
                if (hasEntered)
                {
                    //adapter.OnPointerStay();
                } else
                {
                    Debug.Log("Tobii pointer entered"); // Viewing object first time
                    adapter.OnPointerEnter();
                    hasEntered = true;
                }
            }
            else {
                if (hasEntered)
                {
                    Debug.Log("Tobii pointer exit"); // Not looking anymore
                    adapter.OnPointerExit();
                    hasEntered = false;
                } 
            }           
        }

        public void setAdapter(VRAdapter adapter)
        {
            this.adapter = adapter;
        }
        
    }
}
