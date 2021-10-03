using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatronSpawn : MonoBehaviour
{

    public GameObject patron;

    public float delayBetweenSpawns;
    public float delayBetweenPatrons;

    public int startAmount;
    private int amount;
    

    IEnumerator Start()
    {
        amount = startAmount;

        yield return StartCoroutine(SpawnPatrons());
    }


    private IEnumerator SpawnPatrons()
    {
        
        while(true) {

            for(int i = 0; i < amount; i += 1) {
                SpawnPatron();
                yield return new WaitForSeconds(delayBetweenPatrons);
            }

            yield return new WaitForSeconds(delayBetweenSpawns);
        }
    }

    public void SpawnPatron() {
        Instantiate(patron, transform.position, Quaternion.identity);
    }
}
