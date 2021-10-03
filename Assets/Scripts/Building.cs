using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public TextMesh textName;
    public TextMesh textHealth;
    public TextMesh textRiders;
    public TextMesh textQueue;
    public int startingHealth;
    private int currentHealth;
    private List<Patron> queue = new List<Patron>();
    private List<Patron> riders = new List<Patron>();
    public int rideLength; // Seconds
    public int maxRiders; //
    [HideInInspector]
    public Transform queueStart;
    private float queueDistance = 1f;
    // Start is called before the first frame update

    void Awake() {
        queueStart = transform.Find("Queue");
    }
    
    IEnumerator Start()
    {
        currentHealth = startingHealth;
        textName.text = gameObject.name;

        
        

        yield return StartCoroutine(RideLoop());
    }

    // Update is called once per frame
    void Update()
    {
        textHealth.text = "Health: " + currentHealth.ToString() + " / " + startingHealth.ToString();
        textRiders.text = "Riders: " + riders.Count + " / " + maxRiders.ToString();
        textQueue.text = "Queue: " + queue.Count.ToString();
    }

    IEnumerator RideLoop() {

        while(true) {

            if(currentHealth == 0) {
                EmptyQueue();
                yield return new WaitForSeconds(1);
            } else {
                LoadRiders();
                yield return new WaitForSeconds(rideLength);
                RemoveHealth();
                UnloadRiders();
                yield return new WaitForSeconds(1);
            }
        }
    }

    public void AddToQueue( Patron patron ) {

        queue.Add( patron );
        float move = -queueDistance * queue.Count;
        patron.transform.Translate(new Vector3(0,0, move ));
    }

    void LoadRiders() { 

        while(riders.Count < maxRiders) {

            // No Queue!
            if(queue.Count == 0) {
                break;
            }

            Patron patron = queue[0];
            queue.RemoveAt(0);
            riders.Add(patron);

            shiftRiders();
            shiftQueue();
        }
    }

    void shiftRiders() {
        // todo - move to specific transforms.
        foreach(Patron patron in riders) {
            patron.transform.Translate(new Vector3(queueDistance, 0, 0));

        }
    }

    void shiftQueue() {
        foreach(Patron patron in queue) {
            patron.transform.Translate(new Vector3(0,0, queueDistance ));

        }
    }

    void RemoveHealth() { 

        currentHealth -= riders.Count;

        if(currentHealth < 0) {
            currentHealth = 0;
        }
    }

    void UnloadRiders() { 

        while(riders.Count > 0) {
            Patron patron = riders[0];
            riders.RemoveAt(0);
            patron.AwardPoints(RideQuality()); // Award points for ride.
            patron.NextTarget(); 
        }
    }

    int RideQuality() {
        // Time in queue?
        // Quality of ride?
        return 3;
    }

    void EmptyQueue() {
        while(queue.Count > 0) {
            Patron patron = queue[0];
            queue.RemoveAt(0);
            patron.AwardPoints(0);  // Ride Quality 0 (Broken)
            patron.NextTarget();
        }
    }
}
