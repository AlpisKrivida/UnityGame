using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class BoatStats : MonoBehaviour
{

    public int hitPoints;
    public int totalPoints;
    float totalTime=0;
    int totalCoins=0;
    float totalDistance;
    Vector3 startPoint;

    private bool pickCoins=false;
    private bool shieldAura = false;
    private bool damageEffect = false;
    private bool doubleCoins = false;
    //private bool healhtEffect = false;
    private bool countTotalTime = true;

    public float magnetLastTime = 10;
    public float shieldLastTime = 10;
    public float coinDoubleLastTime = 10;

    public GameObject Text;
    public Collider magnetAura;

    public ParticleSystem shieldAuraParticle;
    public ParticleSystem magnetParticle;
    public ParticleSystem doubleCoinParticle;

    public Slider HealthBarSlider;
    public Slider HealthBarEffect;

    public float DamageOverTime;
    private float HealthDamagetimer = 0;
    private float HealthHealtimer = 0;

    private float magnetAuraTime;
    private float shieldAuraTime;
    private float coinAuraTime;

    public GameObject gameOver;
    public GameObject powerUps;

    private GameObject shieldIcon;
    private GameObject magnetIcon;
    private GameObject coinIcon;

    public Text score;
    public Text distance;
    public Text time;

    public MenuOptions menuOptions;
    public Player player;

    private int doubleCoinMultipleValue = 2;

    // Start is called before the first frame update
    void Start()
    {
        magnetIcon = powerUps.gameObject.transform.GetChild(0).gameObject;
        shieldIcon = powerUps.gameObject.transform.GetChild(1).gameObject;
        coinIcon = powerUps.gameObject.transform.GetChild(2).gameObject;
        startPoint = transform.position;

        //time = magnetLastTime;
        HealthBarSlider.maxValue = hitPoints;
        HealthBarSlider.value = hitPoints;

        HealthBarEffect.maxValue = hitPoints;
        HealthBarEffect.value = hitPoints;

        score.text = totalPoints.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        totalDistance = (transform.position.z - startPoint.z);
        //Debug.Log(Mathf.Round(totalDistance));
        distance.text = Mathf.Round(totalDistance).ToString();

        if (countTotalTime)
        {
            totalTime += Time.deltaTime;
        }

        if (doubleCoins)
        {
            coinAuraTime -= Time.deltaTime;
            doubleCoinParticle.gameObject.SetActive(true);
            if(coinAuraTime < 0)
            {
                coinIcon.SetActive(false);
                doubleCoins = false;
                doubleCoinParticle.gameObject.SetActive(false);
                coinAuraTime = coinDoubleLastTime;
            }


        }

        if (pickCoins)
        {
            magnetAuraTime -= Time.deltaTime;
            magnetAura.enabled= true;
            magnetParticle.gameObject.SetActive(true);
            if(magnetAuraTime < 0)
            {
                magnetIcon.SetActive(false);
                magnetAura.enabled = false;
                pickCoins = false;
                magnetParticle.gameObject.SetActive(false);
                magnetAuraTime = magnetLastTime;
            }
        }

        if (shieldAura)
        {
            shieldAuraTime -= Time.deltaTime;
            shieldAuraParticle.gameObject.SetActive(true);
            if (shieldAuraTime < 0)
            {
                shieldIcon.SetActive(false);
                shieldAura = false;
                shieldAuraParticle.gameObject.SetActive(false);
                shieldAuraTime = shieldLastTime;
            }
        }

        if (damageEffect)
        {
            HealthDamagetimer += Time.deltaTime;
            if(HealthDamagetimer > 1)
            {
                //HealthBarEffect.value = HealthBarSlider.value;
                if(HealthBarEffect.value > HealthBarSlider.value)
                {
                    HealthBarEffect.value -= DamageOverTime;
                }
                else {
                    damageEffect = false;
                    HealthDamagetimer = 0;
                }
            }
        }
    }

    public void UpdatePoints(int points)
    {
        if (doubleCoins == false)
        {
            totalPoints += points;
            ShowText(points);
        }
        else
        {
            totalPoints = totalPoints + points * doubleCoinMultipleValue;
            ShowText(points * 2);
        }
        score.text = totalPoints.ToString();

    }
    private void ShowText(int points)
    {
        var temp = Instantiate(Text, transform.position, Quaternion.identity, transform);
        //temp.GetComponent<TextMesh>().text = points.ToString();
        temp.GetComponentInChildren<TextMesh>().text = points.ToString();
    }

    public void UpdateHitPoints(int points, bool piercing)
    {
        if (points > 0)
        {
            float temp = hitPoints += points;
            if (temp >= HealthBarSlider.maxValue)
            {
                hitPoints = Convert.ToInt32(HealthBarSlider.maxValue);
                HealthBarSlider.value = HealthBarSlider.maxValue;
            }
            else
            {
                hitPoints += points;
                HealthBarSlider.value = hitPoints;
            }
        }
        else
        {
            if (piercing == true || piercing == false && shieldAura == false)
            {
                hitPoints += points;
                HealthBarSlider.value = hitPoints;
                damageEffect = true;
                HealthDamagetimer = 0;
                if (hitPoints <= 0)
                {
                    countTotalTime = false;
                    menuOptions.score.text = (totalPoints+Mathf.Round(totalDistance)).ToString();
                    time.text = System.Math.Round(totalTime, 2).ToString();
                    player.UpdateScore(totalTime, (totalDistance+totalPoints));
                    gameOver.SetActive(true);
                    Time.timeScale = 0;
                }
            }
        }
    }

    public void ActiavteDoubleCoin()
    {
        doubleCoins = true;
        coinIcon.SetActive(true);
        coinAuraTime = coinDoubleLastTime;
    }

    public void ActivateShield()
    {
        shieldAura = true;
        shieldIcon.SetActive(true);
        shieldAuraTime = shieldLastTime;
    }

    public void PickCoins()
    {
        magnetIcon.SetActive(true);
        magnetAuraTime = magnetLastTime;
        pickCoins = true;
    }
}
