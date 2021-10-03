using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booth : MonoBehaviour
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
}
