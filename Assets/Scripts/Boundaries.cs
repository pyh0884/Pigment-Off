using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    [SerializeField]Vector3 screenBounds;
    private void Update()
    {
        screenBounds = new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z);
    }
    private void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, 0, screenBounds.x);
        viewPos.y = Mathf.Clamp(viewPos.y, 0, screenBounds.y);
        transform.position = viewPos;
    }
}
