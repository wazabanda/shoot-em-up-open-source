using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class billBoard : MonoBehaviour
{
    private Camera lookCamera;
    public bool useStaticBillBoard;
    // Start is called before the first frame update
    void Start()
    {
        lookCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (!useStaticBillBoard)
        {
            transform.LookAt(this.lookCamera.transform);
        }
        else {
            transform.rotation = lookCamera.transform.rotation;
        }
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}
