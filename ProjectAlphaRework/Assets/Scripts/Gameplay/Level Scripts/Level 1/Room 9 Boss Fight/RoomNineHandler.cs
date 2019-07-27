using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomNineHandler : MonoBehaviour
{
    [Header ("Dim Lights")]
    private int pulseFrames;
    [SerializeField] private float pulseTimer;                 //pulse timer Var
    [SerializeField] private GameObject lightObject;           //Dim Loghts

    [Header("Bright Lights")]
    [SerializeField] private GameObject brightLights;          //Bright Lights

    [Header("Side Doors")]
    private float doorSpeed = 5;                               //Door movement speed
    [SerializeField] private float enemySpeed = 30;            //enemy run speed

    [Header("Panels")]
    [SerializeField] private GameObject disablePlayerControls; //player control disable object
    [SerializeField] private GameObject darknessPanel;         //Panels that sets room dark

    [Header("Conveyor")]
    public GameObject leftConveyor;                            //Left Conveyor belt Prefab
    public GameObject rightConveyor;                           //right Conveyor Belt Prefab
    public GameObject leftSpawner;                             //Left Spawner Object
    public GameObject rightSpawner;                            //rightSpawner Object
    [SerializeField] private float timeToSpawn = 5;            //Time between conveyor Spawns

    [Header ("Temp Inspector Vars")]
    //[SerializeField] private float timeToSpawn;              //sets the time between spawn variable
    private Collider2D collider2D;                             //Trigger Collider 

    private GameObject conveyorCloneLeft;                      //creates clone for Moving Platform
    private GameObject conveyorCloneRight;                     //creates clone for Moving Platform
    private RoomNineDoorMovement roomNineDoorMovement;         //RoomNineDoorMovement.cs
    private RoomNineEnemyMovement roomNineEnemyMovement;       //RoomNineEnemyMovement.cs

    private bool pulseTimerStart = false;                      //Timer that handles pulses
    private bool pulseStart = false;                           //bool that starts pulses

    [HideInInspector] public bool startConveyor = false;       //bool that starts conveyors 
    [HideInInspector] public bool leftDoorMovement = false;    //bool that triggers doormovement script
    [HideInInspector] public bool enemyMove = false;           //bool that triggers enemy movement script
    [HideInInspector] public bool laserTargetEnemy = false;    //bool that activates laser to target enemy
    [HideInInspector] public bool laserTargerQuantum = false;  //bool that activates laser to target Quantum 
    [HideInInspector] public bool floorSpikes = false;



    private void Start()
    {
        //StartCoroutine(ConveyorSpawner());                               //starts the Instantiate Coroutine

        darknessPanel.SetActive(true);                                   //Activates darkness object
        lightObject.SetActive(false);                                    //Turns Dim Lights off at start
        brightLights.SetActive(false);                                   //turns Bright lights off at start

        collider2D = GetComponent<Collider2D>();                         //Gets Collider Component
        roomNineDoorMovement = GetComponent<RoomNineDoorMovement>();     //Gets Indicated Script
        roomNineEnemyMovement = GetComponent<RoomNineEnemyMovement>();   //Gets indicated Script
    }

    private void Update()
    {
        StartPulseTimer();
        lightPulses();
    }

    /// <summary>
    /// IEnumerator that runs the Whole cutscene at the start of room 9
    /// </summary>
    /// <returns></returns>
    IEnumerator LevelNineIntro()
    {
        disablePlayerControls.SetActive(true);                                                                          // Disables player controls

        pulseTimerStart = true;                                                                                         //sets bool to start pulse timer to true
        pulseStart = true;                                                                                              //Sets pulseStart bool to true so that the light Pulses start
        yield return new WaitForSeconds(5);                                                                             //Waits for 5 seconds

        pulseTimerStart = false;                                                                                        //stops the pulse timer
        pulseStart = false;                                                                                             //stops the pulses
        darknessPanel.SetActive(false);                                                                                 //deactivates the sprite representing Darkness
        brightLights.SetActive(true);                                                                                   //turns on bright lights
        lightObject.SetActive(true);                                                                                    //turns on Dim lights
        yield return new WaitForSeconds(2);                                                                             //waits for 2 seconds

        leftDoorMovement = true;                                                                                        //sets left door movement to true so door can open
        yield return new WaitForSeconds(2);                                                                             //waits for 2 seconds

        enemyMove = true;                                                                                               //sets enemy movement to true so enemy can start moving
        yield return new WaitForSeconds(5);                                                                             //waits for 5 seconds

        leftDoorMovement = false;                                                                                       //Sets door movement to false so door can close
        yield return new WaitForSeconds(2);                                                                             //waits for 2 seconds

        /**************************place Text Code here*****************************/
        yield return new WaitForSeconds(0);

        laserTargetEnemy = true;
        yield return new WaitForSeconds(2);

        /**************************place turret shoot code here*****************************/
        yield return new WaitForSeconds(2);                                                                             //waits for 2 seconds

        laserTargetEnemy = false;
        laserTargerQuantum = true;
        yield return new WaitForSeconds(2);

        Debug.Log("Floor Spikes should move: RoomNineHandler.cs");
        floorSpikes = true;
        disablePlayerControls.SetActive(false);                                                                         //reactivates players control
        startConveyor = true;                                                                                           //star conveyor belt movement

        if (startConveyor)                                                                                              //check if conveyor bool is true
        {
            StartCoroutine(ConveyorSpawner());                                                                          //starts conveyour coroutine
        }
    }

    /// <summary>
    /// Check if Quantum enters the room
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player"))       //Check if Collided object is Quantum
        {
            StartCoroutine(LevelNineIntro());          //start room nine cutscene
            collider2D.enabled = false;                //Deactivates Collider when triggered.
        }
    }

    /// <summary>
    /// starts the timer for the pulses
    /// </summary>
    void StartPulseTimer()
    {
        pulseTimer = 0;                                //sets pulsetimer to 0

        if (pulseTimerStart)
        {
            pulseTimer += Time.deltaTime;              //Increment timer +1 per second
        }
        else
        {
            pulseTimer = 4;                            //sets pulsetimer to 4
        }
    }

    /// <summary>
    /// Handles the Radom generator for the Lights to pulse.
    /// </summary>
    void lightPulses()
    {
        if (pulseStart)
        {
            if (pulseTimer == 0)                            //checks that pulse timer is 0
            {
                darknessPanel.SetActive(true);              //sets darkness effect active
            }
            else if (pulseTimer > 0 && pulseTimer <= 3f)    //check if pulse timer is not 0
            {
                pulseFrames = Random.Range(1, 10);          //Generates a random number between 0 and 10

                if (pulseFrames <= 5)                       //Checks if the pulseFrame variable is less than 5
                {
                    lightObject.SetActive(false);           //Deactivates the Lights
                    darknessPanel.SetActive(true);          //Activates Darkness Object
                }
                else if (pulseFrames >= 6)                  //Checks that the pulse frame variable is higher than 6
                {
                    lightObject.SetActive(true);            //Activates lights 
                    darknessPanel.SetActive(false);         //Deactivates Darkness
                }
            }
        }
    }

    /// <summary>
    /// coroutine that spawn a conveyorbelt at given time to spawn
    /// </summary>
    /// <returns></returns>
    IEnumerator ConveyorSpawner()
    {
        conveyorCloneLeft = Instantiate(leftConveyor, leftSpawner.transform.position, Quaternion.identity);            //instantiates Clone at given location
        conveyorCloneRight = Instantiate(rightConveyor, rightSpawner.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(timeToSpawn);                                                                  // yields for 5 seconds

        StartCoroutine(ConveyorSpawner());                                                                             //spawns another platform
    }
}
