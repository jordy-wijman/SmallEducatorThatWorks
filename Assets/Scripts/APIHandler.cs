using System;
using UnityEngine.Networking;
using System.Collections;
using UnityEngine;
/// <summary>
/// Summary description for Class1
/// </summary>
public class APIHandler : MonoBehaviour
{
    private static APIHandler _instance;
    public static APIHandler Instance { get { return _instance; } }
    public APIHandler()
	{
		if (_instance == null)
        {
            _instance = new APIHandler();
        } 
	}

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void testApi()
    {
        StartCoroutine(GetText());
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://my-json-server.typicode.com/typicode/demo/comments");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }
}
