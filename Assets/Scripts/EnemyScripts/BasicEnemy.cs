using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public QuestManager QuestManager;

    public int EnemyCounter = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForQuest1Complete();      
    }

    void CheckForQuest1Complete()
    {
        if(EnemyCounter <= 0)
        {
            //Debug.Log("Quest 1 finished!");
            QuestManager.FinishQuest1();
        }
    }
}
