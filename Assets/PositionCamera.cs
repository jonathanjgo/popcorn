using UnityEngine;
using System.Collections;

public class PositionCamera : MonoBehaviour {
 
    private float fWidth = 9.0f;  // Desired width 
 
    void Start () {
 
       float fT = fWidth / Screen.width * Screen.height;
       fT = fT / (2.0f * Mathf.Tan (0.5f * Camera.main.fieldOfView * Mathf.Deg2Rad));
       Vector3 v3T = Camera.main.transform.position;
//       v3T.z = -fT;
       v3T.z = -30;
       transform.position = v3T;

    }
}