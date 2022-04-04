using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string SceneName;
    public void SceneChanging()
    {
        SceneManager.LoadScene(SceneName);
    }
    public void DestroyLastInstance()
    {
        GameObject A = GameObject.Find("GameManager");
        Destroy(A);
        GameObject B = GameObject.Find("Main_Song");
        Destroy(B);
    }
}
