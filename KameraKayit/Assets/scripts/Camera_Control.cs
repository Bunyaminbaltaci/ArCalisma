using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

 public class Camera_Control : MonoBehaviour
{

    int currentCamindex =3;
    public WebCamTexture Tex;
    public RawImage display;
    public byte[,] rawByteData;
    public Color[,] data;
    public bool kontrol;

    public void SwitchCam_Cliked()
    {
        //burdaki problem oyundaki kameralarýda görüyor olmasý 3 tane boþ camera oluþuyor
       /* if (WebCamTexture.devices.Length>0)
        {
            currentCamindex += 1;
            Debug.Log(currentCamindex);
            currentCamindex %= WebCamTexture.devices.Length;
        }*/

        if (currentCamindex==3)
        {
            currentCamindex = 4;
            StartStopCam_Cliked();//kameralarý resetlemek için aç kapat yapýyorum
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
            rawByteData=new byte[Tex.width , Tex.height];
            data = new Color[8,8];
            kontrol = true;
        
        }   
    }
   
    public void Kayit() {
      
        if (kontrol == true)
        {
            File.WriteAllText("byte/array/Foo.txt", String.Empty);

             
            StreamWriter writer = new StreamWriter("byte/array/Foo.txt", true);
            for (int i = 0; i < 8; i++)
            {
               
                for (int j = 0; j < 8; j++)
                {
                    data[i, j] = Tex.GetPixel(i, j);
                 
                    Debug.Log(data[i, j]);
                    Debug.Log(i+" " +j);

                   
                    writer.Write(data[i, j]);
                   

                   
                }

                writer.WriteLine(" ");

              

            }
            writer.Close();
          
        }







    }


    }

