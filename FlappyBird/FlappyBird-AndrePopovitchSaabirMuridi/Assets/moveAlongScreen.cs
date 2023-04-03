using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAlongScreen : MonoBehaviour {
    public float moveSpeedMultiplier = 1;
    public bool loop = false;
    GameController gcont;
    
	// Use this for initialization
	void Start () {
        gcont = Camera.main.GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(-gcont.gameMoveSpeed * moveSpeedMultiplier * Time.deltaTime, 0, 0);
        if (loop)
        {
            var bounds = GetComponent<SpriteRenderer>().bounds;
            var leftEdge = gcont.getScreenLeftEdge();
            if (transform.position.x + bounds.extents.x < leftEdge)
            {
                var screenWidth = gcont.getScreenWidth();
                var newXPosition = leftEdge + ((Mathf.Ceil(screenWidth / bounds.size.x) + 1) * bounds.size.x);

                transform.position = new Vector3(newXPosition, transform.position.y, transform.position.z);
            }
        }
    }
}
