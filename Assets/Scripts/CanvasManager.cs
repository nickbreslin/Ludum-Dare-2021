using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    // -----------------------------------------------------------
    // Singleton
    // -----------------------------------------------------------

    public static CanvasManager instance;

    // ------------------------------------------------------------
    // GameObjects
    // ------------------------------------------------------------

    // Keep track of all canvases
    public Canvas[] canvases;



    public GameObject introCanvas;


    // ------------------------------------------------------------
    // State Variables
    // ------------------------------------------------------------
    // Keep track of the current canvas
    private Canvas currentCanvas;

    // Keep track of the current canvas index
    public int currentCanvasIndex;


    // ------------------------------------------------------------
    // Canvas Control Functions
    // ------------------------------------------------------------
    public void NextCanvas()
    {
        // Deactivate the current canvas
        currentCanvas.gameObject.SetActive(false);

        // If current canvas index is less than the length of the canvases array
        if (currentCanvasIndex < canvases.Length - 1)
        {
            // Increment the current canvas index
            currentCanvasIndex++;
        }
        else
        {
            // Set the current canvas index to 0
            currentCanvasIndex = 0;
        }

        // Activate the next canvas
        currentCanvas = canvases[currentCanvasIndex];
        currentCanvas.gameObject.SetActive(true);
    }

    public void PreviousCanvas()
    {
        // Deactivate the current canvas
        currentCanvas.gameObject.SetActive(false);

        // If current canvas index is greater than 0
        if (currentCanvasIndex > 0)
        {
            // Decrement the current canvas index
            currentCanvasIndex--;
        }
        else
        {
            // Set the current canvas index to the length of the canvases array
            currentCanvasIndex = canvases.Length - 1;
        }

        // Activate the previous canvas
        currentCanvas = canvases[currentCanvasIndex];
        currentCanvas.gameObject.SetActive(true);
    }

    public void SetCanvas(int index)
    {
        // Deactivate the current canvas
        currentCanvas.gameObject.SetActive(false);

        // Set the current canvas index to the index
        currentCanvasIndex = index;

        // Activate the canvas at the current canvas index
        currentCanvas = canvases[currentCanvasIndex];
        currentCanvas.gameObject.SetActive(true);
    }

    // ------------------------------------------------------------
    // Unity Methods
    // ------------------------------------------------------------
    void Awake()
    {
        // Singleton
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }


    void Start()
    {

        // Turn off the intro canvas
        introCanvas.SetActive(false);

        // TODO: Turn on theme music
        //AudioManager.instance.PlayBackgroundMusic();

        // Deactivate all canvases
        foreach (Canvas canvas in canvases)
        {
            canvas.gameObject.SetActive(false);
        }

        // Set the current canvas to the currentCanvasIndex
        currentCanvas = canvases[currentCanvasIndex];

        // Activate the current canvas
        currentCanvas.gameObject.SetActive(true);

    }

}
