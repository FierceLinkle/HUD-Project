using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerMain : MonoBehaviour
{
    public FirstPersonController FPC;

    public Slider HealthBar;
    public Slider ManaBar;
    public Slider StaminaBar;

    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public TextMeshProUGUI StaminaText;

    public float PlayerHealth {get; set;}
    public float PlayerMana { get; set; }
    public float PlayerStamina { get; set; }

    public float StaminaTax;
    public float ManaTax;

    //Status Icon Materials
    [SerializeField] private Sprite[] StatusDebuffs; //0. Poison 1. Burn 2. Shock 3. Bleed 4. Slow
    [SerializeField] private Sprite[] StatusBuffs; //0. Strength 1. Mana 2. Stamina 3. Health 4. Magic

    public Image Status1;
    public Image Status2;

    public GameObject FlameHitBox;
    public GameObject ThunderHitBox;
    public GameObject IceHitBox;
    private int SetMagic;
    private bool UsingMagic = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerHealth = 1;
        PlayerMana = 1;
        PlayerStamina = 1;

        HealthBar.value = PlayerHealth;
        ManaBar.value = PlayerMana;
        StaminaBar.value = PlayerStamina;

        Status1.sprite = StatusBuffs[0];
        Status2.sprite = StatusDebuffs[0];

        SetMagic = 1;
    }

    // Update is called once per frame
    void Update()
    {
        #region Mana Boundary
        //Mana boundarys 
        if (ManaBar.value <= 0)
        {
            PlayerMana = 0;
            ManaBar.value = 0;
        }
        #endregion

        MagicSystem();

        StaminaSystem();

        SetBuffs();

        SetDebuffs();

        #region Text Display Values
        //Text display values
        HealthText.SetText((Mathf.Round(PlayerHealth * 100)).ToString());
        ManaText.SetText((Mathf.Round(PlayerMana * 100)).ToString());
        StaminaText.SetText((Mathf.Round(PlayerStamina * 100)).ToString());
        #endregion
    }

    void SetBuffs() //Buff conditions
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Status1.sprite = StatusBuffs[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Status1.sprite = StatusBuffs[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Status1.sprite = StatusBuffs[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Status1.sprite = StatusBuffs[3];
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Status1.sprite = StatusBuffs[4];
        }
    }

    void SetDebuffs() //Debuff conditions
    {
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            Status2.sprite = StatusDebuffs[0];
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            Status2.sprite = StatusDebuffs[1];
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            Status2.sprite = StatusDebuffs[2];
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            Status2.sprite = StatusDebuffs[3];
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Status2.sprite = StatusDebuffs[4];
        }
    }

    void StaminaSystem()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (StaminaBar.value > 0)
            {
                PlayerStamina -= StaminaTax;
                StaminaBar.value -= StaminaTax;
            }
        }
        else
        {
            if (StaminaBar.value < 1)
            {
                //Make coroutine for slight delay
                PlayerStamina += StaminaTax;
                StaminaBar.value += StaminaTax;
            }
        }


        if (StaminaBar.value <= 0)
        {
            FPC.m_RunSpeed = 5;
        }
        else
        {
            FPC.m_RunSpeed = 10;
        }
    } //Run Command

    void MagicSystem()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if ((UsingMagic == false) && (ManaBar.value > 0))
            {
                UsingMagic = true;

                if (ManaBar.value > 0)
                {
                    PlayerMana -= ManaTax;
                    ManaBar.value -= ManaTax;
                }

                if(SetMagic == 1) 
                {
                    FlameHitBox.SetActive(true);
                    StartCoroutine(FireMagicInUse());
                }
                else if (SetMagic == 2)
                {
                    ThunderHitBox.SetActive(true);
                    StartCoroutine(ThunderMagicInUse());
                }
                else if (SetMagic == 3)
                {
                    IceHitBox.SetActive(true);
                    StartCoroutine(IceMagicInUse());
                }

                Debug.Log("Using Magic");
            } 
            else if (UsingMagic)
            {
                Debug.Log("Current spell being cast");
            } 
            else if (ManaBar.value <= 0)
            {
                Debug.Log("Out of Mana");
            }
        } 
    } //Magic Command

    IEnumerator FireMagicInUse()
    {
        yield return new WaitForSeconds(2f);
        FlameHitBox.SetActive(false);
        UsingMagic = false;
    } //Delay between casting fire magic

    IEnumerator ThunderMagicInUse()
    {
        yield return new WaitForSeconds(2f);
        ThunderHitBox.SetActive(false);      
        UsingMagic = false;
    } //Delay between casting thunder magic

    IEnumerator IceMagicInUse()
    {
        yield return new WaitForSeconds(2f);
        IceHitBox.SetActive(false);
        UsingMagic = false;
    } //Delay between casting ice magic

    public void LeftMagic()
    {

        if(SetMagic == 1)
        {
            SetMagic = 3;
            Debug.Log("Set to Ice Magic");
        } else if (SetMagic == 2)
        {
            SetMagic = 1;
            Debug.Log("Set to Flame Magic");
        } else if (SetMagic == 3)
        {
            SetMagic = 2;
            Debug.Log("Set to Thunder Magic");
        }
    } //Function for pause menu

    public void RightMagic()
    {

        if (SetMagic == 1)
        {
            SetMagic = 2;
            Debug.Log("Set to Thunder Magic");
        } else if (SetMagic == 2)
        {
            SetMagic = 3;
            Debug.Log("Set to Thunder Magic");
        } else if (SetMagic == 3)
        {
            SetMagic = 1;
            Debug.Log("Set to Flame Magic");
        }
    } //Function for pause menu

    private void HashedOutCode()
    {
        #region Health Boundary
        /*
        //Health boundarys 
        if (HealthBar.value < 0)
        {
            PlayerHealth = 0;
            HealthBar.value = 0;
        } 
        else if (HealthBar.value > 1)
        {
            PlayerHealth = 1;
            HealthBar.value = 1;
        }
        */
        #endregion  

        /*
        else if (ManaBar.value > 1)
        {
            PlayerMana = 1;
            ManaBar.value = 1;
        }
        */
    } //Unused written code goes here

}
