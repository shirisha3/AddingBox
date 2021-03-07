using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerForBox : MonoBehaviour
{
    
    private float min_X = -2.2f, max_X = 2.2f;
    private bool canMove;
    private float move_Speed = 2f;
    private bool gameOver;
    private bool ingoreCollision;
    private bool ignoreTrigger;
    private Rigidbody2D rb2D;

    private void Awake()
    {
       
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        if (Random.Range(0, 2) > 0)
        {
            move_Speed *= -1f;
        }

        //GameController.instance.currentBox = this;
    }

    // Update is called once per frame
    void Update()
    {
        MoveBox();
    }
    void MoveBox()
    {
        if (canMove)
        {
            Vector3 temp = transform.position;
            temp.x += move_Speed * Time.deltaTime;
            if (temp.x > max_X)
            {
                move_Speed *= -1;
            }
            else if (temp.x < min_X)
            {
                move_Speed *= -1f;
            }
            transform.position = temp;
        }
    }
   public void DropBox()
    {
        
        canMove = false;
        rb2D.gravityScale = Random.Range(2, 4);
    }
}
