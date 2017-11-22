using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface GazeInterface {

    void OnPointerEnter();

    void OnPointerExit();

    void OnPointerStay(RaycastHit hitInformation);

}
