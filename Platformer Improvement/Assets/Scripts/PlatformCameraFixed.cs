using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCameraFixed : MonoBehaviour
{
    public Transform Hero;
    public Texture2D bshLogo;

    void Update () {
        transform.position = new Vector3(Hero.position.x, Hero.position.y + 2f, transform.position.z);
    }

    void OnGUI () {
        GUI.DrawTexture(new Rect(10, 10, 80, 90), bshLogo, ScaleMode.StretchToFill, true);
    }
}
