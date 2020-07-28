using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedometerHandler : MonoBehaviour
{
    [SerializeField] List<Sprite> speed = new List<Sprite>();
    CarEngine carEngine;
    float kmh = 0;
    float maxSpeed = 130f;
    Image image;
    [SerializeField] Text speedText = null;


    // Start is called before the first frame update
    void Start()
    {
        carEngine = GetComponentInParent<CarEngine>();
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        kmh = carEngine.Kmph;

        UpdateSpeed();
        kmh = (int)kmh;
        speedText.text = kmh.ToString() + " KMPH";
    }

    void UpdateSpeed()
    {
        if (kmh >= maxSpeed)
        {
            image.sprite = speed[18];
        }
        else if (kmh >= (maxSpeed / 19) * 18)
        {
            image.sprite = speed[17];
        }
        else if (kmh >= (maxSpeed / 19) * 17)
        {
            image.sprite = speed[16];
        }
        else if (kmh >= (maxSpeed / 19) * 16)
        {
            image.sprite = speed[15];
        }
        else if (kmh >= (maxSpeed / 19) * 15)
        {
            image.sprite = speed[14];
        }
        else if (kmh >= (maxSpeed / 19) * 14)
        {
            image.sprite = speed[13];
        }
        else if (kmh >= (maxSpeed / 19) * 13)
        {
            image.sprite = speed[12];
        }
        else if (kmh >= (maxSpeed / 19) * 12)
        {
            image.sprite = speed[11];
        }
        else if (kmh >= (maxSpeed / 19) * 11)
        {
            image.sprite = speed[10];
        }
        else if (kmh >= (maxSpeed / 19) * 10)
        {
            image.sprite = speed[9];
        }
        else if (kmh >= (maxSpeed / 19) * 9)
        {
            image.sprite = speed[8];
        }
        else if (kmh >= (maxSpeed / 19) * 8)
        {
            image.sprite = speed[7];
        }
        else if (kmh >= (maxSpeed / 19) * 7)
        {
            image.sprite = speed[6];
        }
        else if (kmh >= (maxSpeed / 19) * 6)
        {
            image.sprite = speed[5];
        }
        else if (kmh >= (maxSpeed / 19) * 5)
        {
            image.sprite = speed[4];
        }
        else if (kmh >= (maxSpeed / 19) * 4)
        {
            image.sprite = speed[3];
        }
        else if (kmh >= (maxSpeed / 19) * 3)
        {
            image.sprite = speed[2];
        }
        else if (kmh >= (maxSpeed / 19) * 2)
        {
            image.sprite = speed[1];
        }
        else if (kmh >= (maxSpeed / 19) * 1)
        {
            image.sprite = speed[0];
        }
    }
}
