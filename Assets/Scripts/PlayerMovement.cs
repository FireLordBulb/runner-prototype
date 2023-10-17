using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int lanes;
    [SerializeField] private float laneDistance;
    //[SerializeField] private float lerpSpeed;
    [SerializeField] private InputActionReference MoveLeft, MoveRight;

    private int currentLane = 0;

    void Start()
    {
        currentLane = (int)Mathf.Floor(lanes * 0.5f);
    }

    void Update()
    {

        if (MoveLeft.action.WasPressedThisFrame())
        {
            currentLane -= 1;
        }

        if (MoveRight.action.WasPressedThisFrame())
        {
            currentLane += 1;
        }
        currentLane = (int)Mathf.Clamp(currentLane, 0, lanes - 1);
        transform.position = new Vector3((currentLane - Mathf.Floor(lanes * 0.5f))*laneDistance,0,0);
    }
}
