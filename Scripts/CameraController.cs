using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RayCastSensorType:byte
{
    East,
    South,
    West,
    North,
    NorthEast,
    SouthEast,
    SouthWest,
    NorthWest,
    }
public class CameraController : MonoBehaviour
{
    public float movementSpeed, movementTime, normalSpeed, fastSpeed, rotationAmount,maxHeight,minHeight;
    public Vector3 newPosition, zoomAmount, newZoom, dragStartPosition, dragCurrentPosition, rotateStartPosition, rotateCurrentPosition;
    public Quaternion newRotation;
    public Transform cameraTransform;
   
    
   

    Vector3 startPosition;
    public void StartGame()
    {
        
        startPosition= FindObjectOfType<GenerateMap>().GetStartPosition();
        transform.position = startPosition;
        newPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
       
        HandleMovementInput();
        HandleMouseInput();
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerTilesManager.CancelAllSelectionForBuildings();
        }
    }

    public void SetCameraToThisWizard(GameObject wizard)
    {
        transform.position = wizard.transform.position;
        newPosition = transform.position;
    }

   

    void HandleMouseInput()
    {
        
        if (Input.mouseScrollDelta.y != 0)
        {

            if ((Input.mouseScrollDelta.y < 0 && newZoom.y < maxHeight) || (Input.mouseScrollDelta.y > 0 && newZoom.y > minHeight))
                newZoom += Input.mouseScrollDelta.y * zoomAmount;
        }

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Plane plane = new Plane(Vector3.up, Vector3.zero);
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    float entry;
        //    if (plane.Raycast(ray, out entry))
        //    {
        //        dragStartPosition = ray.GetPoint(entry);
        //    }
        //}
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Plane plane = new Plane(Vector3.up, Vector3.zero);
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    float entry;
        //    if (plane.Raycast(ray, out entry))
        //    {
        //        dragCurrentPosition = ray.GetPoint(entry);
        //        newPosition = transform.position + dragStartPosition - dragCurrentPosition;
        //    }
        //}
        if (Input.GetMouseButtonDown(2))
        {
            rotateStartPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonDown(2))
        {
            rotateCurrentPosition = Input.mousePosition;
            Vector3 difference = rotateStartPosition - rotateCurrentPosition;
            rotateStartPosition = Input.mousePosition;
            newRotation = Quaternion.Euler(Vector3.up * (-difference.x / 5));
        }
    }

    void HandleMovementInput()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            movementSpeed = fastSpeed;
        }
        else
        {
            movementSpeed = normalSpeed;
        }


        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)))
        {
            newPosition += (transform.forward * movementSpeed);
        }
        if ( (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)))
        {
            newPosition += (transform.forward * -movementSpeed);
        }
        if ( (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            newPosition += (transform.right * movementSpeed);
        }
        if ( (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)))
        {
            newPosition += (transform.right * -movementSpeed);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            newRotation *= Quaternion.Euler(Vector3.up * rotationAmount);
        }
        if (Input.GetKey(KeyCode.E))
        {
            newRotation *= Quaternion.Euler(Vector3.up * -rotationAmount);
        }
        if (Input.GetKey(KeyCode.R))
        {
            if (newZoom.y > minHeight)
                newZoom += zoomAmount;
        }
        if (Input.GetKey(KeyCode.F))
        {
            if (newZoom.y < maxHeight)
                newZoom -= zoomAmount;
        }

        //if (Input.GetKey(KeyCode.Alpha1))
        //{
        //    transform.position = FindObjectOfType<DungeonManager>().GetDungeonPosition(1);
        //    newPosition = transform.position;
        //}
        
       
        transform.position = Vector3.Lerp(transform.position, newPosition, Time.deltaTime * movementTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * movementTime);
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, newZoom, Time.deltaTime * movementTime);
    }

    
}