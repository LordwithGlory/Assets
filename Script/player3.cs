using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text;
using System.IO;

namespace MyUnity
{
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
            Debug.Log(Global.poeteryTitle);
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
        // 玩家收集的诗句,从空到有
        public static string collectSen = "";

        public static void setuptitle()
        {
            // 暂时设置有3首古诗可以进行选择
            System.Random rand = new System.Random();
            poetrynum = rand.Next(0, 0);
            poeteryTitle = poetTitles[poetrynum];
        }

        public static void readpoetry()
        {
            string filename = poeteryTitle + ".txt";
            Debug.Log(filename);
            // 默认就是utf-8编码所以不需要单独写编码格式
            // 文件需要在根目录下面，需要system.text这个命名空间
            StreamReader sr = new StreamReader(filename, Encoding.GetEncoding("gb2312"));
            string line;
            int linenum = 0;
            System.Random thesen = new System.Random();
            // 保证是四行大锅
            int crtline = thesen.Next(2, 5);
            while ((line = sr.ReadLine()) != null)
            {
                Debug.Log(line);
                linenum++;
                if (linenum == 1)
                {
                    poeteryTitle = line;
                    continue;
                }
                if (linenum == crtline)
                {
                    guestStc = line;
                    break;
                }
            }
            pos = guestStc.Length - 1;
            Debug.Log(pos);
            crtsen = guestStc;
            guestStc += "某人亮";
        }
    }
}