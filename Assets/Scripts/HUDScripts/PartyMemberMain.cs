using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyMemberMain : MonoBehaviour
{
    public Slider HealthBar;
    public Slider ExpBar;

    //Status Icon Materials
    [SerializeField] private Sprite[] StatusDebuffs; //0. Poison 1. Burn 2. Shock 3. Bleed 4. Slow
    [SerializeField] private Sprite[] StatusBuffs; //0. Strength 1. Mana 2. Stamina 3. Health 4. Magic

    public Image Status1;
    public Image Status2;

    public Image PlayerProfile;

    // Start is called before the first frame update
    void Start()
    {
        HealthBar.value = 1.0f;
        ExpBar.value = 0.0f;

        Status1.sprite = StatusBuffs[0];
        Status2.sprite = StatusDebuffs[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Health()
    {
        
    }

    void Exp()
    {

    }
}
