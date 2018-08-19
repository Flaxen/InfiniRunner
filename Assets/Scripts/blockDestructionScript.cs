using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockDestructionScript : MonoBehaviour {

    public Transform playerTransform;

    private Transform block;

	// Use this for initialization
	void Start () {

        Destroy(GetComponent<Rigidbody2D>());
        block = GetComponent<Transform>();



	}
	
	// Update is called once per frame
	void Update () {

        if (block.position.x < playerTransform.position.x - 5f)
        {
            Destroy(block.root.gameObject);
        }

	}
}
