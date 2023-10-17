using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int lanes;
    [SerializeField] private float laneDistance;
    [SerializeField] private float lerpSpeed;
    [SerializeField] private InputActionReference MoveLeft, MoveRight;

    private int currentLane = 0;
    private int previousLane = 0;
    private float currentLerp = 0;

    void Start()
    {
        currentLane = (int)Mathf.Floor(lanes * 0.5f);
    }

    void Update()
    {
        if (currentLane == previousLane)
        {

            if (MoveLeft.action.WasPressedThisFrame())
            {
                previousLane = currentLane;
                currentLane -= 1;
            }

            if (MoveRight.action.WasPressedThisFrame())
            {
                previousLane = currentLane;
                currentLane += 1;
            }
        }

        currentLane = (int)Mathf.Clamp(currentLane, 0, lanes - 1);
        currentLerp = (currentLane == previousLane) ? 0 : currentLerp + lerpSpeed * Time.deltaTime;
        
        if (currentLerp > 0.99f) {
            previousLane = currentLane;
            currentLerp = 0;
        }

        var posOld = (previousLane - Mathf.Floor(lanes * 0.5f)) * laneDistance;
        var posNew = (currentLane - Mathf.Floor(lanes * 0.5f)) * laneDistance;

        transform.position = new Vector3(Mathf.Lerp(posOld,posNew,currentLerp),0,0);
        
    }
}
