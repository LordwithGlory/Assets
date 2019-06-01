using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyUnity
{
    public class myText : MonoBehaviour
    {
        public Text textcon;
        private Vector3 screenPos;
        // Start is called before the first frame update
        void Start()
        {
            // 需要在初始化之前点击因此出现死循环，我说的是等待那个collectSen的时候
            // while (MyUnity.Global.guestStc == "") ;
            // textcon.text = MyUnity.Global.guestStc;
            // 怀疑和初始化顺序有关 这个玩意儿应该放在最后
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
            namePos.z = 0;
            textcon.transform.position = namePos;
            if (Input.GetButtonDown("Fire1"))
            {
                if (MyUnity.Global.collectSen!="" && textcon.text != MyUnity.Global.collectSen)
                {
                    textcon.text = MyUnity.Global.collectSen;
                    if (MyUnity.Global.crtsen.Contains(textcon.text))
                    {
                        Debug.Log("On the toad");
                        if (MyUnity.Global.crtsen == textcon.text)
                        {
                            Debug.Log("Get all");
                        }
                    }
                    else
                    {
                        Debug.Log("Oh fuck!");
                    }
                }
            }
        }

        void OnGUI()
        {
            screenPos = Camera.main.WorldToScreenPoint(transform.position);
            // 这个地方可以设置文字出现的位置, 现在出现了遮挡
            // GUI.Label(new Rect(screenPos.x, screenPos.y, 200, 20), uistr);
        }
    }
}