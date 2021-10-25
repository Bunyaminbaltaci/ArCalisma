using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using System.Text;

public class Camera_Control : MonoBehaviour
{

    int currentCamindex =3;     
    private WebCamTexture Tex;
    public RawImage display;
    //public byte[] rawByteData;
    public Color[,] data;
    public bool kontrol;
    // ----------------alttaki k�s�m extra deneme
    private RenderTexture renderTexture;
    public byte[] rawByteData;
    private Texture2D texture2D;
    private Rect rect;
    public int bytesPerPixel;
    //--------------------------------------

    // private Action<Texture2D> onscreenshotTaken;
    /* private void Awake()
     {
         RenderPipelineManager.endFrameRendering +=RenderPipelineManager_endFrameRendering;

     }*/
    /*private void RenderPipelineManager_endFrameRendering(ScriptableRenderContext arg1,Camera[] arg2)
    {
        RenderTexture renderTexture = Camera.main.targetTexture;

        Texture2D renderResult = new Texture2D(
                renderTexture.width,
                renderTexture.height,   
                TextureFormat.ARGB32,
                false);

        Rect rect = new Rect(
                 0,
                 0,
                 renderTexture.width,
                 renderTexture.height);

        renderResult.ReadPixels(rect, 0, 0);
        RenderTexture.ReleaseTemporary(renderTexture);
        Camera.main.targetTexture = null;
        onscreenshotTaken(renderResult);
        onscreenshotTaken = null;
    }*/
    /* public void TakeScreenShot(int width,int height,Action<Texture2D> OnScreenShotTaken) {

        display.texture = RenderTexture.GetTemporary(512,512,16);
        this.onscreenshotTaken = onscreenshotTaken;
    }*/
    
    public void Start()
    {
        texture2D = new Texture2D(84, 84, TextureFormat.PVRTC_RGB4, true);
        /* renderTexture = new RenderTexture(84, 84, 24);
        
         rect = new Rect(0, 0, 84, 84);
         display.texture = renderTexture;*/
       /*texture2D = new Texture2D(84, 84, TextureFormat.PVRTC_RGBA4, false);
        texture2D=display.texture as Texture2D;*/
  
   
    }
    public void SwitchCam_Cliked()
    {
        //burdaki problem oyundaki kameralar�da g�r�yor olmas� 3 tane bo� camera olu�uyor
       /* if (WebCamTexture.devices.Length>0)
        {
            currentCamindex += 1;
            Debug.Log(currentCamindex);
            currentCamindex %= WebCamTexture.devices.Length;
        }*/
        if (currentCamindex==3)
        {
            currentCamindex = 4;
            StartStopCam_Cliked();//kameralar� resetlemek i�in a� kapat yap�yorum
            StartStopCam_Cliked();
        }
        else
        {
            currentCamindex = 3;
            StartStopCam_Cliked();
            StartStopCam_Cliked();
           
        }
    }
    public void StartStopCam_Cliked()
    {
        if (Tex !=null)
        {
            display.texture = null;
            Tex.Stop();
            Tex = null;
            kontrol = false;
        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamindex];
            Tex = new WebCamTexture(device.name);
            display.texture = Tex;
            Tex.Play();
            rawByteData=new byte[84*84*bytesPerPixel];
            data = new Color[8,8];
            kontrol = true;
        }   
    } 
    
    public void Kayit() {        
    if (kontrol == true)
    {
           File.WriteAllText(Application.dataPath + "/Foo.txt", String.Empty);
            StreamWriter writer = new StreamWriter(Application.dataPath+"/Foo.txt", true);
             for (int i = 0; i < 8; i++)
               {
                   for (int j = 0; j < 8; j++)
                   {
                     
                        data[i,j] = Tex.GetPixel(i,j);    
                       writer.Write(data[i,j]);
                  //  texture2D.SetPixel(1280,720,Tex.GetPixel(i,j));
                 

                }
               // rawByteData[i] = T;
                   writer.WriteLine(" ");
               }
                    /* byte[] raw = texture2D.EncodeToJPG();
                     Debug.Log(raw);
                     byte[] raw2 = texture2D.EncodeToJPG();
                    Debug.Log(raw2);*/

           
            /*Array.Copy(texture2D.GetRawTextureData(),
                rawByteData, rawByteData.Length);*/
        
           
           // File.WriteAllBytes("byte/array/Foo.txt", rawByteData);
            writer.Close();
    }   
                   
                
    /*
        TakeScreenShot(512,512,(Texture2D screenShootTexture)=> {
            byte[] bytearray = screenShootTexture.EncodeToPNG();
            File.WriteAllBytes("byte/array/Foo.png",bytearray); });
            */
   
    }
    


}   

