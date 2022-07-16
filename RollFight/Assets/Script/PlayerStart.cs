using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStart : MonoBehaviour
{
    private Rigidbody2D rbp;
    public float moveSpeed;
    private Vector3 playerPos;
    private Vector3 goal;
    bool move = true;

    // Start is called before the first frame update
    void Start()
    {
        rbp = this.GetComponent<Rigidbody2D>();
        playerPos = this.transform.position;
        goal = new Vector3(0f, 0f, 0f);
        move = true;
    }

    private void Update() 
    {
        if(playerPos.x <= (goal.x - 4f) && move)
        {
            rbp.velocity = new Vector2(((goal.x - 4f) - playerPos.x) * moveSpeed, 0);
        }
        else
        {
            rbp.velocity = new Vector2(0, 0);
            move = false;
        }
        
    }
    
}
