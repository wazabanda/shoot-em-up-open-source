using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace Helpers
{
    public static class mouseFunctions
    {
        
        public static Vector3 getMousePosition()
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 Worldpos = Camera.main.ScreenToWorldPoint(mousePos);
            return Worldpos;
        }
        public static RaycastHit2D getMouseRaycast()
        {
            return Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        }

    }
    public static class mathFunctions{
        public static float roundToMultiple(float d, float multiple)
        {
            if(d < multiple){
                return 0;
            }
            else{
                return Mathf.Round(d / multiple) * multiple;
            }
        }
    }
}
