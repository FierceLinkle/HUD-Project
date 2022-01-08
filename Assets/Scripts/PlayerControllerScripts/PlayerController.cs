using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    //public GameObject[] HUDSections;

    public PlayerMain PlayerMain;
    public QuestManager QuestManager;

    [SerializeField] private bool[] Quest1to4Active;
    public GameObject Quest5Active;

    public GameObject[] EnemyHitboxes;

    public Slider Health;
    public Slider Mana;
    public float DamageTaken;
    public float HealthRestore;
    public float ManaRestore;

    public Animator SwordSwing;
    public GameObject SwordHitBox;
    private bool IsAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Put complete quest conditions here

        /*
        if ((Quest1to4Active[0] == true) && (Quest1to4Active[1] == true) && (Quest1to4Active[2] == true) && (Quest1to4Active[3] == true)){
            Quest5Active.SetActive(true);
            Debug.Log("Final Quest Active!");
        }
        */

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(SwordSwingSequence());
        }
    }

    //Fire collision
    void OnTriggerEnter(Collider col)
    {
        #region Test Collisions
        if (col.gameObject.tag == "Fire")
        {
            if(Health.value > 0)
            {
                Health.value -= DamageTaken;
                Debug.Log("Taken fire damage!");
            } else if(Health.value < 0)
            {
                Health.value = 0;
            }
        }

        if (col.gameObject.tag == "HealthPickup")
        {
            if (Health.value < 1)
            {
                Health.value += HealthRestore;
                Debug.Log("Health Restored!");
            }
            else if (Health.value > 1)
            {
                Health.value = 1;
            }
        }

        if (col.gameObject.tag == "ManaPickup")
        {
            if(Mana.value < 1)
            {
                Mana.value += ManaRestore;
                PlayerMain.PlayerMana += ManaRestore;
                Debug.Log("Mana restored!");
            }
            else if (Mana.value > 1)
            {
                Mana.value = 1;
            }
        }

        #endregion

        if (col.gameObject.tag == "EnemyHitbox")
        {
            if (Health.value > 0)
            {
                Health.value -= DamageTaken;
                Debug.Log("Taken enemy damage!");
            }
            else if (Health.value < 0)
            {
                Health.value = 0;
            }

            StartCoroutine(HitDelay());
        }

        #region Quest 1

        if (col.gameObject.tag == "Quest1")
        {
            Debug.Log("Collision!");
            QuestManager.Quest1();
            Quest1to4Active[0] = true;
            Destroy(col);
        }

        #endregion

        #region Quest 2

        if (col.gameObject.tag == "Quest2")
        {
            Debug.Log("Collision!");
            QuestManager.Quest2();
            Quest1to4Active[1] = true;
            Destroy(col);
        }

        if (col.gameObject.tag == "MountainPeakQuest")
        {
            Debug.Log("Quest 2 finished!");
            QuestManager.FinishQuest2();
            Destroy(col);
        }


        #endregion

        #region Quest 3

        if (col.gameObject.tag == "Quest3")
        {
            Debug.Log("Collision!");
            QuestManager.Quest3();
            Quest1to4Active[2] = true;
            Destroy(col);
        }

        if (col.gameObject.tag == "ForestMysteryQuest")
        {
            Debug.Log("Quest 3 finished!");
            QuestManager.FinishQuest3();
            Destroy(col);
        }

        #endregion

        #region Quest 4

        if (col.gameObject.tag == "Quest4")
        {
            Debug.Log("Collision!");
            QuestManager.Quest4();
            Quest1to4Active[3] = true;
            Destroy(col);
        }

        if (col.gameObject.tag == "VolcanoRingQuest")
        {
            Debug.Log("Quest 4 finished!");
            QuestManager.FinishQuest4();
            Destroy(col);
        }

        #endregion

        #region Quest 5

        if (col.gameObject.tag == "Quest5")
        {
            Debug.Log("Collision!");
            QuestManager.Quest5();
            Destroy(col);
        }

        #endregion
    }

    IEnumerator HitDelay()
    {
        for(int i = 0; i < EnemyHitboxes.Length; i++)
        {
            EnemyHitboxes[i].SetActive(false);
        }

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < EnemyHitboxes.Length; i++)
        {
            EnemyHitboxes[i].SetActive(true);
        }
    }

    IEnumerator SwordSwingSequence()
    {
        if (!IsAttacking)
        {
            SwordHitBox.SetActive(true);
            IsAttacking = true;
            SwordSwing.SetBool("Swinging", true);
            yield return new WaitForSeconds(1f);
            SwordHitBox.SetActive(false);
            IsAttacking = false;
            SwordSwing.SetBool("Swinging", false);
        }
    }
}
