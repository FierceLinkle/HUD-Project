using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerEquipment : MonoBehaviour
{
    public Image EquippedWeapon;
    public Image EquippedExtra;
    public Image EquippedMagic;

    //0. Basic 1. Rapier 2. Spiked
    [SerializeField] private Sprite[] Swords;
    public GameObject[] SwordGO;

    //0. Basic 1. Middle 2. Epic
    [SerializeField] private Sprite[] Sheilds; 
    public GameObject[] ShieldGO;

    //0. Fire 1. Blizzard 2. Thunder 
    [SerializeField] private Sprite[] Magic;

    // Start is called before the first frame update
    void Start()
    {
        EquippedWeapon.sprite = Swords[0];
        EquippedExtra.sprite = Sheilds[0];
        EquippedMagic.sprite = Magic[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    #region Equipment Set Functions

    public void SetToBasicSword()
    {
        EquippedWeapon.sprite = Swords[0];

        for (int i = 0; i < SwordGO.Length; i++)
        {
            if (i != 0)
            {
                SwordGO[i].SetActive(false);
            }
            else
            {
                SwordGO[i].SetActive(true);
            }
        }
    }

    public void SetToRapier()
    {
        EquippedWeapon.sprite = Swords[1];

        for (int i = 0; i < SwordGO.Length; i++)
        {
            if (i != 1)
            {
                SwordGO[i].SetActive(false);
            }
            else
            {
                SwordGO[i].SetActive(true);
            }
        }
    }

    public void SetToSpikedSword()
    {
        EquippedWeapon.sprite = Swords[2];

        for (int i = 0; i < SwordGO.Length; i++)
        {
            if (i != 2)
            {
                SwordGO[i].SetActive(false);
            }
            else
            {
                SwordGO[i].SetActive(true);
            }
        }
    }

    public void SetToBasicShield()
    {
        EquippedExtra.sprite = Sheilds[0];
      
        for(int i = 0; i < ShieldGO.Length; i++)
        {
            if(i != 0)
            {
                ShieldGO[i].SetActive(false);
            }
            else
            {
                ShieldGO[i].SetActive(true);
            }
        }
        
    }

    public void SetToMiddleShield()
    {
        EquippedExtra.sprite = Sheilds[1];

        for (int i = 0; i < ShieldGO.Length; i++)
        {
            if (i != 1)
            {
                ShieldGO[i].SetActive(false);
            }
            else
            {
                ShieldGO[i].SetActive(true);
            }
        }
    }

    public void SetToEpicShield()
    {
        EquippedExtra.sprite = Sheilds[2];

        for (int i = 0; i < ShieldGO.Length; i++)
        {
            if (i != 2)
            {
                ShieldGO[i].SetActive(false);
            }
            else
            {
                ShieldGO[i].SetActive(true);
            }
        }
    }

    public void SetToFlameMagic()
    {
        EquippedMagic.sprite = Magic[0];
    }

    public void SetToThunderMagic()
    {
        EquippedMagic.sprite = Magic[1];
    }

    public void SetToIceMagic()
    {
        EquippedMagic.sprite = Magic[2];
    }

    #endregion

    #region Menu functions

    public void LeftSword()
    {
        if (EquippedWeapon.sprite == Swords[0])
        {
            SetToSpikedSword();
        }
        else if (EquippedWeapon.sprite == Swords[1])
        {
            SetToBasicSword();
        }
        else if (EquippedWeapon.sprite == Swords[2])
        {
            SetToRapier();
        }
    }

    public void RightSword()
    {
        if (EquippedWeapon.sprite == Swords[0])
        {
            SetToRapier();
        }
        else if (EquippedWeapon.sprite == Swords[1])
        {
            SetToSpikedSword();
        }
        else if (EquippedWeapon.sprite == Swords[2])
        {
            SetToBasicSword();
        }
    }

    public void LeftShield()
    {
        if (EquippedExtra.sprite == Sheilds[0])
        {
            SetToEpicShield();
        }
        else if (EquippedExtra.sprite == Sheilds[1])
        {
            SetToBasicShield();
        }
        else if (EquippedExtra.sprite == Sheilds[2])
        {
            SetToMiddleShield();
        }
    }

    public void RightShield()
    {
        if (EquippedExtra.sprite == Sheilds[0])
        {
            SetToMiddleShield();
        }
        else if (EquippedExtra.sprite == Sheilds[1])
        {
            SetToEpicShield();
        }
        else if (EquippedExtra.sprite == Sheilds[2])
        {
            SetToBasicShield();
        }
    }

    public void LeftMagic()
    {
        if (EquippedMagic.sprite == Magic[0])
        {
            SetToIceMagic();
        }
        else if (EquippedMagic.sprite == Magic[1])
        {
            SetToFlameMagic();
        }
        else if (EquippedMagic.sprite == Magic[2])
        {
            SetToThunderMagic();
        }
    }

    public void RightMagic()
    {
        if (EquippedMagic.sprite == Magic[0])
        {
            SetToThunderMagic();
        }
        else if (EquippedMagic.sprite == Magic[1])
        {
            SetToIceMagic();
        }
        else if (EquippedMagic.sprite == Magic[2])
        {
            SetToFlameMagic();
        }
    }

    #endregion
}
