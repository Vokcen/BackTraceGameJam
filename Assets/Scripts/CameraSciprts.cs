using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;

public class CameraSciprts : MonoBehaviour
{
         public CinemachineVirtualCamera zoomer;
     void Start()
    {       
         
    }

    // Update is called once per frame
    void Update()
    {
        DOTween.To(camZoom,0,1,1);
    }
    void camZoom(float t)
    { zoomer.m_Lens.OrthographicSize+=Mathf.Lerp(60,10,t);}
}
