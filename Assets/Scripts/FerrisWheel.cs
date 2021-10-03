using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FerrisWheel : MonoBehaviour
{
    [SerializeField]
    private Transform _queueStart;

    [SerializeField]
    private Transform _exit;

    [SerializeField]
    private Transform _repairSpot;

    [SerializeField]
    private Transform[] intermediatePositions;

    public GameObject repairSign;

    public bool underRepair = false;

    public float health = 100f;

    void Start()
    {

        repairSign.SetActive(false);
    }

    void Update()
    {
        if (underRepair)
        {
            //Turn on the sign
            repairSign.SetActive(true);
        }
        else
        {
            repairSign.SetActive(false);
        }

        if (isActive)
        {
            //Turn the wheel on the z-axis at speed
            transform.Rotate(Vector3.forward, Time.deltaTime * speed);

            //loop through cars and rotate each car opposite the wheel
            for (int i = 0; i < cars.Length; i++)
            {
                transform.Rotate(Vector3.forward, Time.deltaTime * -speed);
            }

        }



    }

    public void Break()
    {
        underRepair = true;
    }

    public void Fix()
    {
        underRepair = false;
    }

    public Transform Queue { get { return _queueStart; } }

    public Transform Exit { get { return _exit; } }

    public Transform Repair { get { return _repairSpot; } }

    // Ferris Wheel Movement
    public GameObject[] cars;

    public GameObject wheel;

    public float speed;

    public bool isActive = false;


}
