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
        Debug.Log("Ready to jump!");
        SceneManager.LoadScene("SampleScene");
    }
}
