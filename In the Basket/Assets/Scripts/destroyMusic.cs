using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyMusic : MonoBehaviour
{ 
    public void destroyMenuMusic()
    {
        GameObject music = GameObject.FindGameObjectWithTag("menuMusic");
        GameObject.Destroy(music);
    }
}
