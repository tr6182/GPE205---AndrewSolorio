using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] gridPrefabs;
    public int rows;
    public int cols;
    public float roomWidth = 50.0f;
    public float roomHeight = 50.0f;
    public int mapSeed;
    public bool isMapOfTheDay;
    private Room[,] grid;
    // Start is called before the first frame update
    void Start()
    {
        if (isMapOfTheDay)
        {
            mapSeed = DateToInt(DateTime.Now.Date);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) 
        {
            GenerateMap();
        }
    }
    // return a random room
    public GameObject RandomRoomPrefab()
    {
        return gridPrefabs[UnityEngine.Random.Range(0,gridPrefabs.Length)];
    }

    public void GenerateMap()
    {
        // Set our seed
        UnityEngine.Random.InitState(mapSeed);
        // clear out the grid - "colimn" is our x, "row" is our y
        grid = new Room[cols, rows];
        
        // for each grid row...
        for (int currentRow = 0; currentRow < rows; currentRow++)
        {
            // for each column in that row..
            for (int currentCol = 0; currentCol < cols; currentCol++)
            {
                // figure out the location 
                float xPosition = roomWidth * currentCol;
                float zPosition = roomHeight * currentRow;
                Vector3 newPosition = new Vector3(xPosition, 0f, zPosition);

                // create a new grid at the appropriate location
                GameObject tempRoomObj = Instantiate (RandomRoomPrefab(), newPosition, Quaternion.identity) as  GameObject;

                // set its parent
                tempRoomObj.transform.parent = this.transform;

                // give it a meaningful name
                tempRoomObj.name = "Room_" + currentCol + "," + currentRow;

                // get the room object 
                Room tempRoom = tempRoomObj.GetComponent<Room>();

                // open the doors 
                // of we are pm the bottom row, open the north door
                if (currentRow == 0)
                {
                    tempRoom.doorNorth.SetActive(false);
                }
                else if (currentRow == rows -1)
                {
                    // otherwise, if we are on the top row, open the south door
                    Destroy(tempRoom.doorSouth);
                }
                else
                {
                    // otherwise, we are in the middle, so open both doors
                    Destroy (tempRoom.doorNorth);
                    Destroy (tempRoom.doorSouth);
                }

                // if we are on the westmost column, open the east door
                if (currentRow == cols - 1)
                {
                    tempRoom.doorEast.SetActive(false);
                }
                else if (currentCol == cols - 1)
                {
                    // otherwise, if we are on the eastmost coluumn, open the west door
                    tempRoom.doorWest.SetActive(false);
                }
                else
                {
                    // otherwise, we are in the middle, so open both doors
                    tempRoom.doorEast.SetActive(false);
                    tempRoom.doorWest.SetActive(false);
                }

                // save it to the gridd array
                grid[currentCol, currentRow] = tempRoom;
            }
            
            
            
        }
    }
    public int DateToInt(DateTime dateToUse)
    {
        // add our to date up and return it
        return dateToUse.Year + dateToUse.Month + dateToUse.Day + dateToUse.Hour + dateToUse.Minute + dateToUse.Second + dateToUse.Millisecond;
    }
}
