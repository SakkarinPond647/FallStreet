using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void changeScene(string scene_name)
    {
        SceneManager.LoadScene(scene_name);
    }

}
