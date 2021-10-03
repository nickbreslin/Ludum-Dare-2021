using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    private GameObject worker;
    public GameObject worker1;
    public GameObject worker2;
    public GameObject worker3;
    public GameObject worker4;
    public GameObject worker5;

    public int actionType = 0;
    public Transform actionTarget;

    public void SetActionTarget(Transform target) {
        if(worker && actionType > 0 ) {
            actionTarget = target;
            worker.GetComponent<Worker>().SetTarget(target);
        }
    }
    void clearAction() {
        actionTarget = null;
        actionType = 0;

    }

    public void SetWorker(GameObject _worker) {
        worker = _worker;
        clearAction();
    }
    void OnGUI() {

        IncomeUI();
        WorkerUI();
        ActiveWorkerUI();
    }

    void SetAction(int i) {
        actionType = i;
    }

    void IncomeUI() {
        GUI.BeginGroup(new Rect(0, 0, 260, 80));
        GUI.Box(new Rect(10, 20, 80, 30), "$" + Director.instance.incomeManager.income);
        GUI.EndGroup();
    }

    void WorkerUI() {
        GUI.BeginGroup(new Rect(0, Screen.height - 80, 260, 80));
        GUI.Box(new Rect(0, 0, 260, 80), "Select Worker");
        if (GUI.Button(new Rect(10, 30, 40, 40), "1") || Input.GetKeyDown("1"))
        {
            SetWorker(worker1);
        }
        if (GUI.Button(new Rect(60, 30, 40, 40), "2") || Input.GetKeyDown("2"))
        {
            SetWorker(worker2);
        }
        if (GUI.Button(new Rect(110, 30, 40, 40), "3") || Input.GetKeyDown("3"))
        {
            SetWorker(worker3);
        }
        if (GUI.Button(new Rect(160, 30, 40, 40), "4") || Input.GetKeyDown("4"))
        {
            SetWorker(worker4);
        }
        if (GUI.Button(new Rect(210, 30, 40, 40), "5") || Input.GetKeyDown("5"))
        {
            SetWorker(worker5);
        }
        GUI.EndGroup();
    }

    void ActiveWorkerUI() {
        if(worker) {

            string targetLabel = "";
            string actionLabel = "";
            Worker workerScript = worker.GetComponent<Worker>();

            if(workerScript.target) {
                targetLabel = workerScript.target.gameObject.name;
            }

            if(workerScript.isWalking) {
                actionLabel = "walking to " + targetLabel + ".";
            }

            else if(workerScript.isRepairing) {
                actionLabel = "repairing to " + targetLabel + ".";
            } else {
                actionLabel = "idle.";
            }
            GUI.BeginGroup(new Rect(Screen.width - 200, Screen.height - 200, 200, 200));
            GUI.Box(new Rect(0, 0, 200, 200), worker.name + " Actions");
            GUI.Label(new Rect(10, 30, 200, 200), worker.name + " is " + actionLabel);
            if (GUI.Button(new Rect(10, 60, 40, 40), "Fix") || Input.GetKeyDown("f"))
            {
                Debug.Log("Fixing!");
                SetAction(1);
            }
            GUI.EndGroup();
        }
    }

    void AlertsUI() {
        GUI.BeginGroup(new Rect(Screen.width - 200, 0, 200, 200));
        if (GUI.Button(new Rect(10, 60, 40, 40), "Fix") || Input.GetKeyDown("f"))
        {
            Debug.Log("Fixing!");
            SetAction(1);
        }
        GUI.EndGroup();
    }
}
