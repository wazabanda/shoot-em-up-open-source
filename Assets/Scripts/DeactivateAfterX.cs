using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum deactivateType
{
    timer, distance
}
public class DeactivateAfterX : MonoBehaviour
{/// <summary>
/// this script gives control of how a game object is deactivated
/// </summary>
    public deactivateType deactivateType;
[Header("Deactivate auto")]
    public float DeactivateTime = 5;
    float timerCount;

    public float DistanceToDeactivate;
    private GameObject deactivateRefObject;
    private void Update()
    {
        switch (deactivateType)
        {
            case deactivateType.timer:
                if (timerCount >= DeactivateTime)
                {
                    timerCount = 0;
                    Destroy(gameObject);
                   // gameObject.SetActive(false);
                }
                else
                {
                    timerCount += Time.deltaTime;
                }
                break;
            case deactivateType.distance:
                if(deactivateRefObject != null)
                {
                    if( Vector2.Distance(transform.position,deactivateRefObject.transform.position) > DistanceToDeactivate)
                    {
                        Destroy(gameObject);

                        //gameObject.SetActive(false);
                    }
                }
                break;
            default:
                break;
        }

    }
    public void setDeactivateAfterTime(float time)
    {
        DeactivateTime = time;
        timerCount = 0;
        deactivateType = deactivateType.timer;
    } 

    public void deactivateWithDistance(GameObject deactivteReferenceObject,float deactivateDistance) 
    {
        deactivateType = deactivateType.distance;
    }
}
