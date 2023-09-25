using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceController : MonoBehaviour
{
 

    public void ChangeScence()
    {
        SceneManager.LoadScene("Game");
        Debug.Log("Load");
    }
}
