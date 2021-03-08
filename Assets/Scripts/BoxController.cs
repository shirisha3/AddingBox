using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    private float min_X = -2.8f, max_X = 2.8f;
    private bool canMove;
    private float move_Speed = 2f;
    private bool gameOver;
    private bool ignoreCollision;
    private bool ignoreTrigger;
    private Rigidbody2D rb2D;

    //using delegate 
    public delegate void changeEnemyColor(Color col);
    public static event changeEnemyColor onPlayerBoxHit;

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

        GameController.instance.currentBox = this;
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
   
    void Landed()
    {
          if (gameOver)
            return;
        ignoreTrigger = true;
        ignoreCollision = true;
       
        GameController.instance.SpawnNewBox();
        GameController.instance.MoveCamera();
       
    }
    void ReplayGame()
    {
        GameController.instance.RestartGame();
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (ignoreCollision)
            return;
        if (target.gameObject.tag=="Platform"|| target.gameObject.tag == "Box")
        {
           Invoke("Landed",1f);
            
            ignoreCollision = true;
        }
        if (target.gameObject.tag == "Enemy")
        {
            onPlayerBoxHit(Color.red);
            CancelInvoke("Landed");
            Invoke("ReplayGame", 2f);
        }
    }
    private void OnTriggerEnter2D(Collider2D target)
    {
        if (ignoreTrigger)
            return;
        if(target.tag=="GameOver")
        {
           CancelInvoke("Landed");
            gameOver = true;
            ignoreTrigger = true;
            Invoke("ReplayGame", 2f);
        }
    }
}