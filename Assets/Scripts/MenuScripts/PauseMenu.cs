using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.Characters.FirstPerson;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    public FirstPersonController fps;
    public PlayerEquipment PlayerEquip;
    public PlayerMain PlayerMain;

    public static bool IsPaused = false;

    public GameObject PauseMenuUI;
    public GameObject SettingsMenuUI;
    public GameObject EquipmentMenuUI;
    public GameObject SkillsMenuUI;

    public GameObject[] HUDToggle;
    public TextMeshProUGUI[] ToggleCheck;
    public bool[] SettingsToggle;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (IsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        fps.m_MouseLook.SetCursorLock(true);
        fps.enabled = true;
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        IsPaused = false;
    }

    void Pause()
    {
        fps.m_MouseLook.SetCursorLock(false);
        fps.enabled = false;
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        IsPaused = true;
    }

    public void EquipmentMenu()
    {
        PauseMenuUI.SetActive(false);
        EquipmentMenuUI.SetActive(true);
    }

    #region Equipment Toggle functions

    public void LeftSword()
    {
        PlayerEquip.LeftSword();
    }

    public void RightSword()
    {
        PlayerEquip.RightSword();
    }

    public void LeftShield()
    {
        PlayerEquip.LeftShield();
    }

    public void RightShield()
    {
        PlayerEquip.RightShield();
    }

    public void LeftMagic()
    {
        PlayerEquip.LeftMagic();
        PlayerMain.LeftMagic();
    }

    public void RightMagic()
    {
        PlayerEquip.RightMagic();
        PlayerMain.RightMagic();
    }

    #endregion

    public void SkillsMenu()
    {
        PauseMenuUI.SetActive(false);
        SkillsMenuUI.SetActive(true);
    }

    public void Settings()
    {
        PauseMenuUI.SetActive(false);
        SettingsMenuUI.SetActive(true);
    }

    #region Settings Toggle functions

    public void Bars()
    {
        if (!SettingsToggle[0])
        {
            HUDToggle[0].SetActive(false);
            ToggleCheck[0].SetText("Off");
            SettingsToggle[0] = true;
        } else
        {
            HUDToggle[0].SetActive(true);
            ToggleCheck[0].SetText("On");
            SettingsToggle[0] = false;          
        }
    }

    public void Nav()
    {
        if (!SettingsToggle[1])
        {
            HUDToggle[1].SetActive(false);
            ToggleCheck[1].SetText("Off");
            SettingsToggle[1] = true;
        }
        else
        {
            HUDToggle[1].SetActive(true);
            ToggleCheck[1].SetText("On");
            SettingsToggle[1] = false;
        }
    }

    public void WorldInfo()
    {
        if (!SettingsToggle[2])
        {
            HUDToggle[2].SetActive(false);
            ToggleCheck[2].SetText("Off");
            SettingsToggle[2] = true;
        }
        else
        {
            HUDToggle[2].SetActive(true);
            ToggleCheck[2].SetText("On");
            SettingsToggle[2] = false;
        }
    }

    public void Moveset()
    {
        if (!SettingsToggle[3])
        {
            HUDToggle[3].SetActive(false);
            ToggleCheck[3].SetText("Off");
            SettingsToggle[3] = true;
        }
        else
        {
            HUDToggle[3].SetActive(true);
            ToggleCheck[3].SetText("On");
            SettingsToggle[3] = false;
        }
    }

    public void Equip()
    {
        if (!SettingsToggle[4])
        {
            HUDToggle[4].SetActive(false);
            ToggleCheck[4].SetText("Off");
            SettingsToggle[4] = true;
        }
        else
        {
            HUDToggle[4].SetActive(true);
            ToggleCheck[4].SetText("On");
            SettingsToggle[4] = false;
        }
    }

    public void Quests()
    {
        if (!SettingsToggle[5])
        {
            HUDToggle[5].SetActive(false);
            ToggleCheck[5].SetText("Off");
            SettingsToggle[5] = true;
        }
        else
        {
            HUDToggle[5].SetActive(true);
            ToggleCheck[5].SetText("On");
            SettingsToggle[5] = false;
        }
    }

    public void Party()
    {
        if (!SettingsToggle[6])
        {
            HUDToggle[6].SetActive(false);
            ToggleCheck[6].SetText("Off");
            SettingsToggle[6] = true;
        }
        else
        {
            HUDToggle[6].SetActive(true);
            ToggleCheck[6].SetText("On");
            SettingsToggle[6] = false;
        }
    }

    public void Misc()
    {
        if (!SettingsToggle[7])
        {
            HUDToggle[7].SetActive(false);
            ToggleCheck[7].SetText("Off");
            SettingsToggle[7] = true;
        }
        else
        {
            HUDToggle[7].SetActive(true);
            ToggleCheck[7].SetText("On");
            SettingsToggle[7] = false;
        }
    }

    #endregion

    public void Back()
    {
        SettingsMenuUI.SetActive(false);
        SkillsMenuUI.SetActive(false);
        EquipmentMenuUI.SetActive(false);
        PauseMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}
