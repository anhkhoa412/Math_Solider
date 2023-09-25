using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ImageLoader : MonoBehaviour
{

    public RawImage rImage;
    public string imageUrl;

    private void Start()
    {
        StartCoroutine(LoadImageFromInternet(imageUrl));
    }
    IEnumerator LoadImageFromInternet(string url)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(url))
        {
            yield return webRequest.SendWebRequest();
            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                Texture2D texture = DownloadHandlerTexture.GetContent(webRequest);
                rImage.texture = texture;
            }
            else
            {
                Debug.Log("Error");
            }
        }

        yield return null;
    }
}
