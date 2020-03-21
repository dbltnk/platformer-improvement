using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinishFixed : MonoBehaviour
{
    void OnGUI () {
        GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2, 200, 25), "You got the treasure!");
        if (GUI.Button(new Rect(Screen.width / 2 - 25, Screen.height / 2 + 20, 80, 25), "Play Again!")) {
            SceneManager.LoadScene("level1");
        }
    }
}
