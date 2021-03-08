using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxController.onPlayerBoxHit += Damage;
    }

 void Damage(Color col)
    {
        transform.GetComponent<SpriteRenderer>().color = col;
    }
    private void OnDisable()
    {
        BoxController.onPlayerBoxHit -= Damage;
    }
}
