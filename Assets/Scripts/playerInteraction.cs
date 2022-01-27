using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Helpers;
public class playerInteraction : MonoBehaviour
{
    public static playerInteraction instance;
    public LayerMask interactLayer;
    public float interactDistance;
    private GameObject interactedOBJ;
    private bool grabbed = false;
    public LineRenderer interectRender;
    private SpringJoint SpringJoint;
    Camera mainCamera;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        interectRender.enabled = false;
        mainCamera = Camera.main;
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Mouse1) && grabbed == false)
        {
            if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
            {
                interactedOBJ = hit.collider.gameObject;
                SpringJoint = gameObject.AddComponent<SpringJoint>();
                SpringJoint.connectedBody = interactedOBJ.GetComponent<Rigidbody>();
                grabbed = true;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            interectRender.enabled = false;

            Destroy(SpringJoint);
            interactedOBJ = null;
            grabbed = false;
        }
        if(grabbed && interactedOBJ != null)
        {
            interectRender.enabled = true;
            interectRender.SetPosition(0, interactedOBJ.transform.position);
            interectRender.SetPosition(1, mouseFunctions.getMousePosition());
        }
    }
    public Vector3 getRayCastPosition()
    {
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            return hit.point;
        }
        return transform.position + (transform.forward*5);
    }
}
