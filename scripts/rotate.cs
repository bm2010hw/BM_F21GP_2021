using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    // Spin the object on itself at 40 degrees/second.
    void Update()
    {
        this.transform.RotateAround(this.GetComponent<Collider>().bounds.center, Vector3.up, 40f * Time.deltaTime);
    }
}
