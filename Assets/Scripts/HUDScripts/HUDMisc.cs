using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDMisc : MonoBehaviour
{
    public TextMeshProUGUI Version;

    public int MainUpdate;
    public int SubUpdate;

    public Image Network;
    public Image Difficulty;
    public Image Saving;

    [SerializeField] private Sprite NetworkSprite;
    [SerializeField] private Sprite DifficultySprite;
    [SerializeField] private Sprite SavingSprite;

    // Start is called before the first frame update
    void Start()
    {
        Version.SetText("Ver: " + MainUpdate.ToString() + "." + SubUpdate.ToString());

        Network.sprite = NetworkSprite;
        Difficulty.sprite = DifficultySprite; 
        Saving.sprite = SavingSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
