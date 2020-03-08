using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasFollowPlayer : MonoBehaviour
{
    public Transform transform1;
    public Vector3 vec;
    void Update()
    {
        transform.position = transform1.position + vec;
    }
}
