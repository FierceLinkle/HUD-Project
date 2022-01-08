using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldNavigation : MonoBehaviour
{
    public GameObject iconPrefab;
    List<Landmarks> Landmark = new List<Landmarks>();

    public RawImage CompassImage;
    public Transform Player;

    public float MaxDistance = 200f;

    float CompassUnit;

    public Landmarks Town;
    public Landmarks Forest;
    public Landmarks Mountain;
    public Landmarks EnemyCamp;
    public Landmarks Volcano;

    // Start is called before the first frame update
    void Start()
    {
        CompassUnit = CompassImage.rectTransform.rect.width / 360f;

        AddLandmark(Town);
        AddLandmark(Forest);
        AddLandmark(Mountain);
        AddLandmark(EnemyCamp);
        AddLandmark(Volcano);
    }

    // Update is called once per frame
    void Update()
    {
        CompassImage.uvRect = new Rect(Player.localEulerAngles.y / 360f, 0f, 1f, 1f);

        foreach (Landmarks Marker in Landmark)
        {
            Marker.image.rectTransform.anchoredPosition = GetPosOnCompass(Marker);

            float dist = Vector2.Distance(new Vector2(Player.transform.position.x, Player.transform.position.y), Marker.position);
            float scale = 0f;

            if(dist < MaxDistance)
            {
                scale = 1f - (dist / MaxDistance);
            }

            Marker.image.rectTransform.localScale = Vector3.one * scale;
        }
    }

    public void AddLandmark (Landmarks Marker)
    {
        GameObject NewLandmark = Instantiate(iconPrefab, CompassImage.transform);
        Marker.image = NewLandmark.GetComponent<Image>();
        Marker.image.sprite = Marker.Icon;

        Landmark.Add(Marker);
    }

    Vector2 GetPosOnCompass(Landmarks Marker)
    {
        Vector2 playerPos = new Vector2(Player.transform.position.x, Player.transform.position.z);
        Vector2 playerFwd = new Vector2(Player.transform.forward.x, Player.transform.forward.z);

        float angle = Vector2.SignedAngle(Marker.position - playerPos, playerFwd);

        return new Vector2(CompassUnit * angle, 0f);
    }
}
