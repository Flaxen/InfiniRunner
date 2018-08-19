using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapGeneration : MonoBehaviour {

    public const float STANDARD_Y_LEVEL = 0.2842047f;


    public GameObject prefab;
    public GameObject[] mapBlocks;

    private float newBlockWidth;
    private float blockSpawningLine;    //x-position on ground block to cross which spawn new block
    //private float previousBlockPosX;    //center x-position of previous spawned block
    private Transform player;           //player prefab
    private GameObject newBlock;
    private GameObject previousBlock;

    // Use this for initialization
    void Start () {

        player = GetComponent<Transform>();

        //previousBlockPosX = prefab.transform.position.x;
        previousBlock = prefab;
        blockSpawningLine = 0f;         // initial value. Changes on later spawns.

    }
	
	// Update is called once per frame
	void Update () {

        prefab = mapBlocks[Random.Range(0, mapBlocks.Length)];
        newBlockWidth = prefab.GetComponent<BoxCollider2D>().size.x;
        float previousBlockWidth = previousBlock.GetComponent<BoxCollider2D>().size.x;
        newBlock = prefab;

        SpriteRenderer previousSprite = previousBlock.GetComponentInChildren<SpriteRenderer>();

        // Block generation
        if (player.position.x > blockSpawningLine)
        {
            // Calculated values for new x and y placing blocks accordingly
            float calculatedX = previousSprite.bounds.center.x + previousBlockWidth/2 + newBlockWidth/2;
            float calculatedY = (STANDARD_Y_LEVEL - 0.91f) - newBlock.GetComponent<BoxCollider2D>().offset.y - (newBlock.GetComponent<BoxCollider2D>().size.y - 0.2344884f)/2;

            // Creates new "block"
            newBlock = (GameObject)Instantiate(prefab, 
                new Vector3(calculatedX, calculatedY, prefab.transform.position.z), Quaternion.identity) 
                as GameObject;


            // may need to change as random block spawns are implemented
            //prefab = newBlock;
            previousBlock = newBlock;
            //previousBlockPosX = newBlock.transform.position.x;
            blockSpawningLine = newBlock.transform.position.x - 3f;


            




        }




    }
}
