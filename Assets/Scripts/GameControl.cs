using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static int brickSize = 0;
    public Slider slider;
    public Canvas finishCanvas;
    public Text resultText,sequenceText;

    
    [SerializeField] public GameObject[] runners;
    private GameObject tempObject;

    public static int runnerSequence;
    public static bool gameState = true;

    void Start()
    {
        slider.minValue = 0;
        slider.maxValue = 96;
        slider.value = 0;
        brickSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        print("Brizk Size : "+brickSize);
        slider.value = (float)(brickSize *2);


        if (brickSize == 48) {
            finishCanvas.gameObject.SetActive(true);
            resultText.text = "Level Complated !";
        }

        float boyX = runners[0].transform.position.x;

        for (int i =0;i<runners.Length-1;i++) {
            for (int j = i; j < runners.Length; j++) {
                if (runners[i].transform.position.x > runners[j].transform.position.x) {
                    tempObject = runners[j];
                    runners[j] = runners[i];
                    runners[i] = tempObject;
                }
            }
        }

        for (int i = 0; i < runners.Length; i++) {
            if (runners[i].name == "Boy")
            {
                print("Boy Sequence : " + (i+1));
                runnerSequence = (i + 1);
                sequenceText.text = "#" + (i+1);
            }
        }

        if (!gameState) {
            resultText.text = "You Lost !";
            finishCanvas.gameObject.SetActive(true);
        }

    }
}
