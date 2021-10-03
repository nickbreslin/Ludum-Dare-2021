using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Worker : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    public float speed = 20;
    public int repairPerSecond = 5;
    [HideInInspector]
    public bool isRepairing = false;
    [HideInInspector]
    public bool isWalking = false;

    void OnMouseDown() {
        Debug.Log(gameObject.name + " clicked");
        Director.instance.guiManager.SetWorker(this.gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        if(!target) {
            return;
        }
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        isWalking = true;
        // Check if the position of the cube and sphere are approximately equal.
        if (Vector3.Distance(transform.position, target.position) < 0.001f)
        {
            isWalking = false;
            Building building = target.gameObject.GetComponentInParent<Building>();
            
            if(building && !isRepairing) {
                isRepairing = true;
                StartCoroutine(DoRepair(building));
            }

        }
    }

    public void SetTarget( Transform _target) {
        isRepairing = false;
        target = _target;
    }

    IEnumerator DoRepair(Building building) {
        while( isRepairing ) {
            if(!building.DoRepair( repairPerSecond )) {
                SetTarget(null);
            }
            yield return new WaitForSeconds(1);
        }
      
    }
}
