using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestManager : MonoBehaviour
{
    public GameObject[] ExpandQuestList;
    public GameObject ClosedQuestList;
    public GameObject QuestStartedText;
    public GameObject QuestCompleteText;
    private bool ListToggle = false;

    public string[] Quests;
    public bool[] QuestTaken;

    private TextMeshProUGUI ExpandQuestText;
    private TextMeshProUGUI QuestListText;
    private TextMeshProUGUI ClosedQuestText;

    public float ActiveQuests = 0;

    [SerializeField] private bool[] Quest1to4Active;
    public GameObject Quest5Active;
    public GameObject Quest5Enemy;

    private Vector3 Enemy5Position = new Vector3(10, 0, 60);

    // Start is called before the first frame update
    void Start()
    {
        //this.Quests = new string[6];
        //this.QuestTaken = new bool[6];

        ExpandQuestText = ExpandQuestList[0].GetComponent<TextMeshProUGUI>();
        ExpandQuestText.SetText("< Current Active Quests (" + ActiveQuests.ToString() + ")");

        ClosedQuestText = ClosedQuestList.GetComponent<TextMeshProUGUI>();
        ClosedQuestText.SetText("> (" + ActiveQuests.ToString() + ")");

        QuestListText = ExpandQuestList[1].GetComponent<TextMeshProUGUI>();
        QuestListText.SetText("1. " + Quests[0] + "\n" + "2. " + Quests[1] + "\n" + "3. " + Quests[2] + "\n" + "4. " + Quests[3] + "\n" + "5. " + Quests[4]);
    }

    // Update is called once per frame
    void Update()
    {
        #region Quest List Toggle
        //Quest List Toggle
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!ListToggle)
            {
                for (int i = 0; i <= 1; i++)
                {
                    ExpandQuestList[i].SetActive(true);
                }
                ClosedQuestList.SetActive(false);

                ListToggle = true;
            }
            else
            {
                for (int i = 0; i <= 1; i++)
                {
                    ExpandQuestList[i].SetActive(false);
                }
                ClosedQuestList.SetActive(true);

                ListToggle = false;
            }
        }
        #endregion
        
        ExpandQuestText.SetText("< Current Active Quests (" + ActiveQuests.ToString() + ")");
        ClosedQuestText.SetText("< (" + ActiveQuests.ToString() + ")");

        AddQuest();
        QuestListText.SetText("1. " + Quests[0] + "\n" + "2. " + Quests[1] + "\n" + "3. " + Quests[2] + "\n" + "4. " + Quests[3] + "\n" + "5. " + Quests[4]);
        FinishQuest();

        if ((Quest1to4Active[0] == true) && (Quest1to4Active[1] == true) && (Quest1to4Active[2] == true) && (Quest1to4Active[3] == true))
        {
            Quest5Active.SetActive(true);
            Debug.Log("Final Quest Active!");
        }
    }

    void AddQuest()
    {
      
    }

    public void Quest1()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] == string.Empty)
            {
                Quests[i] = "Clear out the zombie camp!";
                ActiveQuests += 1;

                StartCoroutine(QuestStarted());

                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void FinishQuest1()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] == "Clear out the zombie camp!")
            {
                StartCoroutine(QuestCompleted());

                Quests[i] = string.Empty;
                ActiveQuests -= 1;

                for (int j = 0; j < Quests.Length; j++)
                {
                    if (j > i)
                    {
                        Quests[j - 1] = Quests[j];
                    }
                }

                Quest1to4Active[0] = true;

                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void Quest2()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] != string.Empty)
            {
                continue;
            }
            else
            {
                Quests[i] = "Climb the mountain!";
                ActiveQuests += 1;

                StartCoroutine(QuestStarted());

                break;
            }
        }
    }

    public void FinishQuest2()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] == "Climb the mountain!")
            {
                StartCoroutine(QuestCompleted());

                Quests[i] = string.Empty;
                ActiveQuests -= 1;

                for (int j = 0; j < Quests.Length; j++)
                {
                    if (j > i)
                    {
                        Quests[j - 1] = Quests[j];
                    }
                }

                Quest1to4Active[1] = true;

                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void Quest3()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] != string.Empty)
            {
                continue;
            }
            else
            {
                Quests[i] = "There's something strange in the forest?";
                ActiveQuests += 1;

                StartCoroutine(QuestStarted());

                break;
            }
        }
    }

    public void FinishQuest3()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] == "There's something strange in the forest?")
            {
                StartCoroutine(QuestCompleted());

                Quests[i] = string.Empty;
                ActiveQuests -= 1;

                for (int j = 0; j < Quests.Length; j++)
                {
                    if (j > i)
                    {
                        Quests[j - 1] = Quests[j];
                    }
                }

                Quest1to4Active[2] = true;

                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void Quest4()
    {
        for (int i = 0; i < Quests.Length ; i++)
        {
            if (Quests[i] != string.Empty)
            {
                continue;
            }
            else
            {
                Quests[i] = "Find the lost ring at the volcano!";
                ActiveQuests += 1;

                StartCoroutine(QuestStarted());

                break;
            }
        }
    }

    public void FinishQuest4()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] == "Find the lost ring at the volcano!")
            {
                StartCoroutine(QuestCompleted());

                Quests[i] = string.Empty;
                ActiveQuests -= 1;

                for (int j = 0; j < Quests.Length; j++)
                {
                    if (j > i)
                    {
                        Quests[j - 1] = Quests[j];
                    }
                }

                Quest1to4Active[3] = true;

                break;
            }
            else
            {
                continue;
            }
        }
    }

    public void Quest5()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] != string.Empty)
            {
                continue;
            }
            else
            {
                Quests[i] = "Protect the town from the troll!";
                ActiveQuests += 1;

                StartCoroutine(QuestStarted());

                Instantiate(Quest5Enemy, Enemy5Position, new Quaternion(0,0,0,0));

                break;
            }
        }
    }

    public void FinishQuest5()
    {
        for (int i = 0; i < Quests.Length; i++)
        {
            if (Quests[i] == "Protect the town from the troll!")
            {
                StartCoroutine(QuestCompleted());

                Quests[i] = string.Empty;
                ActiveQuests -= 1;

                for (int j = 0; j < Quests.Length; j++)
                {
                    if (j > i)
                    {
                        Quests[j - 1] = Quests[j];
                    }
                }

                break;
            }
            else
            {
                continue;
            }
        }
    }

    void FinishQuest()
    {
        //Make proper ends to quests (in PlayerController script)
        if (Input.GetKeyDown(KeyCode.F))
        {
            for (int i = 0; i < Quests.Length; i++)
            {
                if (Quests[i] == "Clear out the zombie camp!")
                {
                    Quests[i] = string.Empty;
                    ActiveQuests -= 1;

                    for (int j = 0; j < Quests.Length; j++)
                    {
                        if (j > i)
                        {
                            Quests[j - 1] = Quests[j];
                        }
                    }

                    Quest1to4Active[0] = true;

                    StartCoroutine(QuestCompleted());

                    break;
                } 
                else
                {
                    continue;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            for (int i = 0; i < Quests.Length; i++)
            {
                if (Quests[i] == "Climb the mountain!")
                {
                    Quests[i] = string.Empty;
                    ActiveQuests -= 1;

                    for (int j = 0; j < Quests.Length; j++)
                    {
                        if (j > i)
                        {
                            Quests[j - 1] = Quests[j];
                        }
                    }

                    Quest1to4Active[1] = true;

                    StartCoroutine(QuestCompleted());

                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            for (int i = 0; i < Quests.Length; i++)
            {
                if (Quests[i] == "There's something strange in the forest?")
                {
                    Quests[i] = string.Empty;
                    ActiveQuests -= 1;

                    for (int j = 0; j < Quests.Length; j++)
                    {
                        if (j > i)
                        {
                            Quests[j - 1] = Quests[j];
                        }
                    }

                    Quest1to4Active[2] = true;

                    StartCoroutine(QuestCompleted());

                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            for (int i = 0; i < Quests.Length; i++)
            {
                if (Quests[i] == "Find the lost ring at the volcano!")
                {
                    Quests[i] = string.Empty;
                    ActiveQuests -= 1;

                    for (int j = 0; j < Quests.Length; j++)
                    {
                        if (j > i)
                        {
                            Quests[j - 1] = Quests[j];
                        }
                    }

                    Quest1to4Active[3] = true;

                    StartCoroutine(QuestCompleted());

                    break;
                }
                else
                {
                    continue;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            for (int i = 0; i < Quests.Length; i++)
            {
                if (Quests[i] == "Protect the town from the troll!")
                {
                    Quests[i] = string.Empty;
                    ActiveQuests -= 1;

                    for (int j = 0; j < Quests.Length; j++)
                    {
                        if (j > i)
                        {
                            Quests[j - 1] = Quests[j];
                        }
                    }

                    StartCoroutine(QuestCompleted());

                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }

    IEnumerator QuestStarted()
    {
        QuestStartedText.SetActive(true);
        yield return new WaitForSeconds(2f);
        QuestStartedText.SetActive(false);
    }

    IEnumerator QuestCompleted()
    {
        QuestCompleteText.SetActive(true);
        yield return new WaitForSeconds(2f);
        QuestCompleteText.SetActive(false);
    }
}
