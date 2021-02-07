using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int totalPoint;
    public int stagePoint;
    public int stageIndex;
    public int health;
    public Transform reposionPoint;
    public PlayerMove player;

    public void NextStage()
    {
        stageIndex++;
        totalPoint += stagePoint;
        stagePoint = 0;

    }

    public void HealthDown()
    {
        if (health > 1)
        {
            health--;
        }
        else
        {
            //Player Die Effect
            player.OnDie();
            //Result UI
            Debug.Log("죽었습니다. Result UI");
            //Retry Button UI
            Debug.Log("retry button");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Player Reposition
            if (health > 1)
            {
                collision.attachedRigidbody.velocity = Vector2.zero;
                collision.transform.position = reposionPoint.position;
            }

            //Health down
            HealthDown();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
