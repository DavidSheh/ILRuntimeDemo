using System;
using System.Collections.Generic;
using UnityEngine;

namespace Hotfix
{
    public class Game
    {
        public static void Initialize()
        {
            Debug.Log("Initialize ...");
            // 初始化
        }

        public static void ClickBtn()
        {
            Debug.Log("ClickBtn ...");

            // 显示 UI
            var prefab = Resources.Load<GameObject>("UITest");
            var obj = GameObject.Instantiate(prefab);
            obj.transform.SetParent(GameObject.Find("UIRoot").transform);
            obj.transform.localPosition = Vector3.zero;
            var baseUI = obj.GetComponent<BaseUI>();
            new UILogic(baseUI);
        }
    }
}
