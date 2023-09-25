using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EventExample : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(Delay());
    }

    IEnumerator Delay()
    {
        Debug.Log("Hello");
        yield return new WaitForSeconds(2f);
        Debug.Log("CGO Unity");
    }
}
