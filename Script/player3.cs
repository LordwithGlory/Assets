using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player3 : MonoBehaviour
{
    //在场景中鼠标点击地面后，角色可以移动到目标位置

    private Vector3 screenPos;
    private Vector3 mousePos;
    private Vector3 mousePosInw;
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            mouseFollow();
        }
    }

    void mouseFollow()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos = Input.mousePosition;
        mousePos.z = screenPos.z;
        mousePosInw = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = mousePosInw;
    }
}
