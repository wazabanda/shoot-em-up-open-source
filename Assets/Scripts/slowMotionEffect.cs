using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowMotionEffect : MonoBehaviour
{
    public static slowMotionEffect instance;
    public float shake_Intensity;
    public float slowDownFactor = 0.05f;//how much we slow down
    public float slowDownDuration = 2f;
    public float originalFixedDeltaTime;
    public bool slowed = false;
    private void Awake()
    {
        instance = this;
        slowed = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (slowed == true) { 
            Time.timeScale += (1 / slowDownDuration) * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
          if(Time.timeScale == 1f)
            {
                slowed = false;
                Time.fixedDeltaTime = originalFixedDeltaTime;
            }
        } }
    public void doslowmo(float slowDownFactor = 0.05f,float slowDownDuration = 2f)
    {   if (slowed == false)
        {
            this.slowDownDuration = slowDownDuration;
            this.slowDownFactor = slowDownFactor;
            //screenEffects.Instance.ShakeCamera(shake_Intensity, 0.1f);
            Time.timeScale = slowDownFactor;
            originalFixedDeltaTime = Time.fixedDeltaTime;
            Time.fixedDeltaTime = Time.timeScale * .02f;
            
            slowed = true;
        }
    }
}
