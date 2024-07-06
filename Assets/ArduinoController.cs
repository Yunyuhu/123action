// using System.IO.Ports;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public class ArduinoController : MonoBehaviour
{
    // public Image imageToShow; // 衣二衫Logo
    // public Sprite pngSprite;
    // //OL風
    // public Image image1; //OL風邊框
    // public Sprite image1Sprite;
    // public GameObject object1OL; //OL風衣服

    //嘻哈風
    // public Image image2; //嘻哈風邊框
    // public Sprite image2Sprite;
    // public GameObject object1HipHop; //嘻哈風衣服
    private Wireless _controller;
    public AudioSource audioSource;
    // public AudioClip music1; //OL風
    // public AudioClip music2; //嘻哈風
    public AudioClip camera; //相機音效

    void Start()
    {
        // imageToShow.enabled = true; // 開始時開啟衣二衫Logo
        // image1.enabled = false; // 開始時隱藏 OL風邊框
        // image2.enabled = false; // 開始時隱藏 嘻哈風邊框
        // object1OL.SetActive(false); // 開始時隱藏 object1 OL
        // object1HipHop.SetActive(false); // 開始時隱藏 object1 HipHop
        // Invoke("ExecuteOnceInFixedUpdate", Time.fixedDeltaTime);
        _controller = GetComponent<Wireless>();
        
        // serialPort.Open();
    }
    void FixedUpdate(){
        ppp();
        
    }

    void ppp(){
        
        if(__controller.isTrigger && controller.cmd=='p'){
            _controller.cmd='q';
            Debug.Log(_controller.cmd);
            Debug.Log("op");
            CameraSound();
        }
        // Debug.Log("open");
    }

    // void ExecuteOnceInFixedUpdate(){
    //     if( _controller.cmd=='p'){
    //         Debug.Log("op");
    //         CameraSound();
    //     }
    //     Debug.Log("open");
    // }

    // void Update()
    // {
    //     if (serialPort.IsOpen)
    //     {
    //         try
    //         {
    //             // string value = serialPort.ReadLine().Trim();
    //             // if (value.Contains("A")) //感測到有人
    //             // {
    //             //     StartToshow();
    //             // }
    //             // else if (value.Contains("1") || value.Contains("2")) //下一個濾鏡
    //             // {
    //             //     int nextStep;
    //             //     if (int.TryParse(value, out nextStep))
    //             //     {
    //             //         HandleNextStep(nextStep);
    //             //     }
    //             // }
    //             if(value.Contains("p")){
    //                 CameraSound();
    //             }
    //             // else if (value.Contains("camerasound")) //快門聲
    //             // {
    //             //     CameraSound();
    //             // }
    //         }
    //         catch (System.Exception ex)
    //         {
    //             Debug.LogWarning("Serial Port Error: " + ex.Message);
    //         }
    //     }
    // }
    // void StartToshow() //感測到有人
    // {
    //     imageToShow.enabled = false; // 隱藏Logo

    //     // 顯示初始濾鏡
    //     object1OL.SetActive(true); // 顯示 object1 OL
    //     audioSource.clip = music1;
    //     audioSource.Play(); // 播放音樂1
    //     image1.sprite = image1Sprite;
    //     image1.enabled = true; // 顯示 image1
    // }

    // void HandleNextStep(int nextStep) //下一個濾鏡
    // {
    //     if (nextStep == 1)
    //     {
    //         // 切換到嘻哈風格
    //         ChangeToHipHopStyle();
    //     }
    //     else if (nextStep == 2)
    //     {
    //         // 切換到OL風格
    //         ChangeToOLStyle();
    //     }
    //     else
    //     {
    //         Debug.LogWarning("Unknown next step value: " + nextStep);
    //     }
    // }

    // void ChangeToHipHopStyle()
    // {
    //     // 關閉 OL 風格
    //     object1OL.SetActive(false);
    //     image1.enabled = false;

    //     // 開啟 嘻哈風格
    //     object1HipHop.SetActive(true);
    //     audioSource.clip = music2;
    //     audioSource.Play(); // 播放音樂2
    //     image2.sprite = image2Sprite;
    //     image2.enabled = true; // 顯示 image2
    // }

    // void ChangeToOLStyle()
    // {
    //     // 關閉 嘻哈風格
    //     object1HipHop.SetActive(false);
    //     image2.enabled = false;

    //     // 開啟 OL 風格
    //     object1OL.SetActive(true);
    //     audioSource.clip = music1;
    //     audioSource.Play(); // 播放音樂1
    //     image1.sprite = image1Sprite;
    //     image1.enabled = true; // 顯示 image1
    // }

    void CameraSound() //快門聲
    {   
        audioSource.Stop();
        audioSource.clip = camera;
        audioSource.Play(); // 播放camera sound
    }

    
}