using System;
using System.Collections;
using System.IO;
using UnityEngine;

public class Main : MonoBehaviour
{
    ILRuntime.Runtime.Enviorment.AppDomain appdomain;
    void Start()
    {
        StartCoroutine(LoadILRuntime());
    }

    IEnumerator LoadILRuntime()
    {
        appdomain = new ILRuntime.Runtime.Enviorment.AppDomain();
#if UNITY_ANDROID
    WWW www = new WWW(Application.streamingAssetsPath + "/Hotfix.dll");
#else
        WWW www = new WWW("file:///" + Application.streamingAssetsPath + "/Hotfix.dll");
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            Debug.LogError(www.error);
        byte[] dll = www.bytes;
        www.Dispose();
#if UNITY_ANDROID
    www = new WWW(Application.streamingAssetsPath + "/Hotfix.pdb");
#else
        www = new WWW("file:///" + Application.streamingAssetsPath + "/Hotfix.pdb");
#endif
        while (!www.isDone)
            yield return null;
        if (!string.IsNullOrEmpty(www.error))
            Debug.LogError(www.error);
        byte[] pdb = www.bytes;
        using (System.IO.MemoryStream fs = new MemoryStream(dll))
        {
            using (System.IO.MemoryStream p = new MemoryStream(pdb))
            {
                appdomain.LoadAssembly(fs, p, new Mono.Cecil.Pdb.PdbReaderProvider());
            }
        }
        OnILRuntimeInitialized();
    }

    void OnILRuntimeInitialized()
    {
#if UNITY_EDITOR
        // 启动调试服务
        appdomain.DebugService.StartDebugService(56000);
#endif

        appdomain.DelegateManager.RegisterDelegateConvertor<UnityEngine.Events.UnityAction>((act) =>
        {
            return new UnityEngine.Events.UnityAction(() =>
            {
                ((Action)act)();
            });
        });        
        appdomain.Invoke("Hotfix.Game", "Initialize", null, null);
    }

    public void OnBtnClick()
    {
        appdomain.Invoke("Hotfix.Game", "ClickBtn", null, null);
    }
}