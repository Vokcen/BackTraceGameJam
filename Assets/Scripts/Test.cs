using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.U2D;
using UnityEngine.Experimental.Rendering.Universal;
using Cinemachine;

public class Test : MonoBehaviour
{  public GameObject sphere;
    public float tempDistance;
    public float distance;
    public SpriteShapeController spriteShape = default;
    public bool canUse;
    int node;
    Vector3 startPosition, endPosition;
    float startHeight;
    public float environmentChangeDuration = 5f;

    //Effects
    public ParticleSystem environmentParticle;
    public Light2D environmentLight;

    private void Start()
    {
        canUse = true;
    }


    public void GizmoView(Vector3 gizmo)
    {
        endPosition = spriteShape.transform.InverseTransformPoint(gizmo);
        
         distance = 5;
        distance = ForLoop(distance);
        Instantiate(sphere,spriteShape.spline.GetPosition(node),transform.rotation);
        startPosition = spriteShape.spline.GetPosition(node);
           
   
    }
    public void AddPoint(Vector3 worldPosition)
    {
            ///////spriteShape.spline.GetSpriteIndex(node);

       // endPosition = spriteShape.transform.InverseTransformPoint(worldPosition);

        // distance = 3;
        //distance = ForLoop(distance);
       
      //  startPosition = spriteShape.spline.GetPosition(node);
       // startHeight = spriteShape.spline.GetHeight(node);
        DOTween.To(AnimatePosition, 0, 1, 0.5f);






    }

    public float ForLoop(float distance)
    { 
        for (int i = 0; i < spriteShape.spline.GetPointCount(); i++)
        {  
            Vector3 pointPosition = spriteShape.spline.GetPosition(i);
            tempDistance = Vector3.Distance(endPosition, pointPosition);
             
          
            if (tempDistance < distance)
            {
                distance = tempDistance;
                node = i;
                Debug.Log(i);
                Debug.DrawLine(endPosition, pointPosition);
                Debug.Log(tempDistance);

            }
        }

        return distance;
    }

    void AnimatePosition(float t)
    {
        spriteShape.spline.SetPosition(node, Vector3.Lerp(startPosition, endPosition, t));
    }
    private void OnDrawGizmos()
    {
    

    }
}
