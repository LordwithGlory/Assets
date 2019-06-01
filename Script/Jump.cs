using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void jumpSence()
    {
        // mark the solution:https://blog.csdn.net/u011607490/article/details/84239490
        // mark the bottom:https://www.cnblogs.com/isayes/p/6370168.html
        Debug.Log("Ready to jump!");
        SceneManager.LoadScene("SampleScene");
    }
}
