using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour
{
    private string uistr = "HELLO";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnMouseDown()
    {
        // 加入一个碰撞器之后才可以 BOX COLINDER 2D
        Destroy(this.gameObject);
        //gameObject.GetComponent<Renderer>().enabled = false;
    }

    void OnGUI()
    {
        GUI.Label(new Rect(gameObject.transform.position.x, gameObject.transform.position.y, 200, 20), uistr);
    }
}
