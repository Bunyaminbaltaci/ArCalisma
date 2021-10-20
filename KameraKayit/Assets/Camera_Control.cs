using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

 public class Camera_Control : MonoBehaviour
{

    int currentCamindex = 0;
    WebCamTexture Tex;
    public RawImage display;
   public void SwitchCam_Cliked()
    {
        if (WebCamTexture.devices.Length>0)
        {
            currentCamindex += 1;
            currentCamindex %= WebCamTexture.devices.Length;
        }

    }
    public void StartStopCam_Cliked()
    {
        if (Tex !=null)
        {
            display.texture = null;
            Tex.Stop();
            Tex = null;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamindex];
            Tex = new WebCamTexture(device.name);
            display.texture = Tex;
            Tex.Play();
        }   
    }

    void Start()
    {
    }

    void Update()
    {
       
    }
}
