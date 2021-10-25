using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotate : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(Vector3.forward * 1f);
    }
}
