using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Transform playerSpawnTransform;
   
    //prefabs
    public GameObject playerControllerPrefab;
    public GameObject tankPawnPrefab;

    //PatrolAI tank
    public GameObject patrolAIControllerPrefab;

    public List<PlayerController> players;

    public PawnSpawnPoint[] spawnPoints;

    public MapGenerator mapGenerator;

    private void Start()
    {
        // temp code
       // SpawnPlayer();
       mapGenerator = GetComponent<MapGenerator>();

       mapGenerator.GenerateMap();

        spawnPoints = FindObjectsOfType<PawnSpawnPoint>();

        foreach (PawnSpawnPoint p in spawnPoints)
        {
            Debug.Log(p.gameObject.name);
        }

        SpawnPatrolAI(spawnPoints[Random.Range(0,spawnPoints.Length)]);
    }

    //Awake is called when the object is first created - before even Start can run!
    private void Awake()
    {
        // if the instance doesn't exist yet...
        if (instance == null)
        {
            //this is the instance
            instance = this;
            //don't destroy it uf we load a new scene
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //otherwise, there is already an instance, so destroy this gameObject
            Destroy(gameObject);
        }
        
        }
    public void SpawnPlayer()
    {
        // Spawn the player controller at (0,0,0) with no rotation
        GameObject newPlayerObj = Instantiate(playerControllerPrefab, Vector3.zero, Quaternion.identity)as GameObject;

        // spawn the pawn and connect it to the controller
        GameObject newPawnObj = Instantiate(tankPawnPrefab, playerSpawnTransform.position, playerSpawnTransform.rotation)as GameObject;
        
        // get the player controller component and pawn component
        Controller newController = newPlayerObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<NoiseMaker>();
        newPawn.noiseMaker = newPawnObj.GetComponent<NoiseMaker>();
        newPawn.noiseMakerVolume = 3;

        newPawnObj.AddComponent<PowerupManager>();

        // hook them up
        newController.pawn = newPawn;
    }

    public void SpawnPatrolAI(PawnSpawnPoint spawnPoint)
    {
        // spawn the AI Controller at (0,0,0) with no rotation
        GameObject newAIObj = Instantiate(patrolAIControllerPrefab, Vector3.zero, Quaternion.identity) as GameObject;

        // spawn the pawn and connect it to the controller 
        GameObject newPawnObj = Instantiate(tankPawnPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;

        // attach appropriate components and hook AIController to pawn

        Controller newController =newPawnObj.GetComponent<Controller>();
        Pawn newPawn = newPawnObj.GetComponent<Pawn>();

        newPawnObj.AddComponent<PowerupManager>();

        newController.pawn = newPawn;

        newAIObj.GetComponent<AIController>().waypoints[0] = spawnPoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[1] = spawnPoint.nextWaypoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[2] = spawnPoint.nextWaypoint.nextWaypoint.transform;
        newAIObj.GetComponent<AIController>().waypoints[3] = spawnPoint.nextWaypoint.nextWaypoint.nextWaypoint.transform;
    }


}
