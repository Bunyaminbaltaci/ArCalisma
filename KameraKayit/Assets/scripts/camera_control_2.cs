using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class camera_control_2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera cam;
    private RenderTexture renderTexture;
    public int bytesPerPixel;
    private byte[] rawByteData;
    private Texture2D texture2D;
    private Rect rect;

    void Start()
    {
        renderTexture = new RenderTexture(84, 84, 24);
        rawByteData = new byte[84 * 84 * bytesPerPixel];
        texture2D = new Texture2D(84, 84, TextureFormat.RGB24, false);
        rect = new Rect(0, 0, 84, 84);
        cam.targetTexture = renderTexture;

    }
    public void documentation() {

        cam.Render();
        // Read pixels to texture
        RenderTexture.active = renderTexture;
        texture2D.ReadPixels(rect, 0, 0);
        Array.Copy(texture2D.GetRawTextureData(), rawByteData, rawByteData.Length);
        File.WriteAllBytes("byte/array/Foo.txt", rawByteData); // Requires System.IO

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
