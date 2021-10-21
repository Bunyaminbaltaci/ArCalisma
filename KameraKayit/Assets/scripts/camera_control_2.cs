using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class camera_control_2 : MonoBehaviour
{
    public Camera cam;
    private RenderTexture renderTexture;
    public int bytesPerPixel;
    private byte[] rawByteData;
    private Texture2D texture2D;
    private Rect rect;
    public void SwitchCam_Cliked()
    {
      
    }
    public void StartStopCam_Cliked()
    {
       
    }

    public void Kayit()
    {
        run_cmd();

    }
   
    public void  Start()
    {

        renderTexture = new RenderTexture(84, 84, 24);
        rawByteData = new byte[84 * 84 * bytesPerPixel];
        texture2D = new Texture2D(84, 84, TextureFormat.RGB24, false);
        rect = new Rect(0, 0, 84, 84);
        cam.targetTexture = renderTexture;
    }
    public void run_cmd()
    {

        cam.Render() ;
        // Read pixels to texture
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(rect, 0, 0);
        Array.Copy(texture2D.GetRawTextureData(), rawByteData, rawByteData.Length);
        File.WriteAllBytes("/Path/to/byte/array/Foo.txt", rawByteData); // Requires System.IO
    }



}
