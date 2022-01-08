using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WorldInfo : MonoBehaviour
{
    public GameObject[] HUDElements; //0. Bars 1. Navigation 2. MiscWorldInfo 3. Moveset 4. Equipeed Info 5. Quests 6. Party Status 7. Misc

    public TextMeshProUGUI AreaText;
    public TextMeshProUGUI TimeDateText;

    //Mini Map here

    public Image Weather;
    public Image Temperature;

    [SerializeField] private Sprite[] WeatherSprites; //0.Cold 1. Normal 3. Sunny
    [SerializeField] private Sprite[] TemperatureSprites; //0. Freezing 1. Normal 2. Boiling

    public Slider Health;
    public float WeatherDamageTaken;

    private Coroutine WeatherDamage;

    // Start is called before the first frame update
    void Start()
    {
        WeatherDamage = StartCoroutine(TakeTempDamage());

        StartCoroutine(Time());

        Weather.sprite = WeatherSprites[1];

        Temperature.sprite = TemperatureSprites[1];
    }

    // Update is called once per frame
    void Update()
    {
            
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Town")
        {
            HUDElements[0].SetActive(false);
            HUDElements[1].SetActive(true);
            HUDElements[2].SetActive(true);
            HUDElements[3].SetActive(false);
            HUDElements[4].SetActive(false);
            HUDElements[5].SetActive(true);
            HUDElements[6].SetActive(false);
            HUDElements[7].SetActive(true);

            AreaText.SetText("Town");

            Temperature.sprite = TemperatureSprites[1];
            StopCoroutine(WeatherDamage);

            SetWeather();
        } 

        if (col.gameObject.tag == "Forest")
        {
            HUDElements[0].SetActive(true);
            HUDElements[1].SetActive(true);
            HUDElements[2].SetActive(true);
            HUDElements[3].SetActive(false);
            HUDElements[4].SetActive(false);
            HUDElements[5].SetActive(true);
            HUDElements[6].SetActive(false);
            HUDElements[7].SetActive(true);

            AreaText.SetText("Forest");

            Temperature.sprite = TemperatureSprites[1];
            StopCoroutine(WeatherDamage);

            SetWeather();
        } 

        if (col.gameObject.tag == "Mountain")
        {
            HUDElements[0].SetActive(true);
            HUDElements[1].SetActive(true);
            HUDElements[2].SetActive(true);
            HUDElements[3].SetActive(false);
            HUDElements[4].SetActive(false);
            HUDElements[5].SetActive(true);
            HUDElements[6].SetActive(false);
            HUDElements[7].SetActive(true);

            AreaText.SetText("Mountain");

            Temperature.sprite = TemperatureSprites[1];
            StopCoroutine(WeatherDamage);

            SetWeather();
        }

        if (col.gameObject.tag == "MountainPeak")
        {
            Temperature.sprite = TemperatureSprites[0];
            WeatherDamage = StartCoroutine(TakeTempDamage());

            Weather.sprite = WeatherSprites[0];
        }

        if (col.gameObject.tag == "EnemyCamp")
        {
            for (int i = 0; i < HUDElements.Length; i++)
            {
                HUDElements[i].SetActive(true);
            }

            AreaText.SetText("Enemy Camp");

            Temperature.sprite = TemperatureSprites[1];
            StopCoroutine(WeatherDamage);

            SetWeather();
        } 

        if (col.gameObject.tag == "Volcano")
        {
            HUDElements[0].SetActive(true);
            HUDElements[1].SetActive(true);
            HUDElements[2].SetActive(true);
            HUDElements[3].SetActive(false);
            HUDElements[4].SetActive(false);
            HUDElements[5].SetActive(true);
            HUDElements[6].SetActive(false);
            HUDElements[7].SetActive(true);

            AreaText.SetText("Volcano");

            Temperature.sprite = TemperatureSprites[2];
            WeatherDamage = StartCoroutine(TakeTempDamage());

            SetVolcanoWeather();
        }

        if (col.gameObject.tag == "GrassyLands")
        {
            for (int i = 0; i < HUDElements.Length; i++)
            {
                HUDElements[i].SetActive(true);
            }

            AreaText.SetText("Grassy Lands");

            Temperature.sprite = TemperatureSprites[1];
            StopCoroutine(WeatherDamage);

            SetWeather();
        } //Change HUD setting for final build

        //Set Weather conditions
    }

    void SetWeather()
    {
        if (Random.Range(0f, 1f) <= 0.4f)
        {
            Weather.sprite = WeatherSprites[2];
        }
        else if ((Random.Range(0f, 1f) > 0.4f) && (Random.Range(0f, 1f) <= 0.9f))
        {
            Weather.sprite = WeatherSprites[1];
        } else
        {
            Weather.sprite = WeatherSprites[0];
        }

    }

    void SetVolcanoWeather()
    {
        if (Random.Range(0f, 1f) <= 0.5f)
        {
            Weather.sprite = WeatherSprites[2];
        }
        else
        {
            Weather.sprite = WeatherSprites[1];
        }

    }

    IEnumerator TakeTempDamage()
    {
        while (true)
        {
            if (Health.value > 0)
            {
                yield return new WaitForSeconds(0.1f);
                Health.value -= WeatherDamageTaken;
                //Debug.Log("Taken Weather Damage damage!");
            }
            else if (Health.value < 0)
            {
                Health.value = 0;
            }
            yield return new WaitForSeconds(2f);
        }
    }

    IEnumerator Time()
    {
        while (true)
        {
            var now = System.DateTime.Now;
            TimeDateText.text = now.ToString("dd/MM  HH:mm");
            yield return new WaitForSeconds(0.2f);
        }
    }
}
