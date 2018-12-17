using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public Transform target;
    private float distance = 10;
    public  float lift = 1.5F;

  

    
    // Update is called once per frame
    void Update () {
        transform.position = target.position + new Vector3 (0, lift, distance);
        transform.LookAt(target);
    


	}
}
