using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class ScaleEffect : MonoBehaviour
{
    private Vector3 initialScale;
    private bool isScaling = false;
    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && !isScaling)
        {
            // Tang size cuar doi len
            StartCoroutine(ScaleObject(Vector3.one * 2f)); // tang len gap doi
        }
        else if (Input.GetKeyDown(KeyCode.B) && !isScaling)
        {
            // Giam size cuar doi len
            StartCoroutine(ScaleObject(Vector3.one * 0.5f)); // giam di 1 nua
        }
    }

    IEnumerator ScaleObject(Vector3 targetScale)
    {
        isScaling = true;

        float duration = 1.0f; // Thoi gian dien ra
        float elapsedTime = 0f;

        Vector3 start = transform.localScale;
        while (elapsedTime < duration)
        {
            transform.localScale = Vector3.Lerp(start, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null; // cho 1 frame moi
        }

        isScaling = false;
    }


}
