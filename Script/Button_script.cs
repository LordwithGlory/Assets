using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 这个button文件似乎是没用的
public class Button_script : MonoBehaviour
{
    public GameObject Head;
    public Transform UI;
    private float baseFomat;
    private float currentFomat;
    private float Scale;
    // Start is called before the first frame update
    void Start()
    {
        baseFomat = Vector3.Distance(Head.transform.position, Camera.main.transform.position);
        Scale = 1 - UI.localScale.x;
        currentFomat = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (baseFomat != currentFomat)
        {
            currentFomat = Vector3.Distance(Head.transform.position, Camera.main.transform.position);
            float myscale = baseFomat / currentFomat - Scale;
            UI.position = WorldToUI(Head.transform.position);
            UI.localScale = Vector3.one * Scale;
        }
    }

    public static Vector3 WorldToUI(Vector3 point)
    {
        Vector3 pt= Camera.main.WorldToScreenPoint(point);
        Vector3 ff = Camera.main.ScreenToWorldPoint(pt);
        ff.z = 0;
        return ff;
    }
}
