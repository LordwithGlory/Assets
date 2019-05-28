using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class player3 : MonoBehaviour
{
    //在场景中鼠标点击地面后，角色可以移动到目标位置

    private Vector3 screenPos;
    private Vector3 mousePos;
    private Vector3 mousePosInw;
    void Start()
    {
        Global.setuptitle();
        Global.readpoetry();
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

public static class Global
{
    // 诗的编号
    private static int poetrynum;
    // 分配文字时候确定在句子中的位置（包括混淆文字）
    public static int pos;
    private static string[] poetTitles = { "静夜思", "咏鹅", "望岳" };
    public static string poeteryTitle = "";
    public static string hintStc = "";
    // 从这个里读文字，存在混淆的文字
    public static string guestStc = "";
    // 正确的诗句
    public static string crtsen = "";

    public static void setuptitle()
    {
        // 暂时设置有3首古诗可以进行选择
        System.Random rand = new System.Random();
        poetrynum = rand.Next(1, 3);
        poeteryTitle = poetTitles[poetrynum];
    }

    public static void readpoetry()
    {
        string filename = poeteryTitle + ".txt";
        try
        {
            // 默认就是utf-8编码所以不需要单独写编码格式
            using(StreamReader sr=new StreamReader(filename))
            {
                // 准备设计第一行是这首诗标题和作者
                string line;
                int linenum=0;
                System.Random thesen = new System.Random();
                // 找一行进行试错
                while ((line=sr.ReadLine())!=null)
                {
                    linenum++;
                    if (linenum == 1)
                    {
                        poeteryTitle = line;
                        continue;
                    }
                    if (linenum == thesen.Next(2, 5) || linenum == 5)
                    {
                        guestStc = line;
                        break;
                    }
                }
                pos = guestStc.Length - 1;
                crtsen = guestStc;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Data);
        }
    }
}