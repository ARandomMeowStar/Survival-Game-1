using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using TMPro;
using System.Security.Cryptography;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHp;
    [SerializeField] private Image hpBar;

    [Space]
    [SerializeField]private float maxHunger;
    [SerializeField] private float hungerLostPerSec;
    [SerializeField]private Image hungerBar;
    [Space]
    [SerializeField] private int startMoney;
    [SerializeField] private TMP_Text moneyTmp;
    private float curHp;
    private float curHunger;
    public int CurMoney => curMoney;
    private int curMoney;
    void Start()
    {
        curHp= maxHp;
        hpBar.fillAmount= curHp/maxHp;

        curHunger = maxHunger;
        hungerBar.fillAmount= curHunger / maxHunger;
        curMoney=startMoney;
        moneyTmp.text = curMoney.ToString();
    }
    public void TakeDamage(float dmg)
    {
        curHp -=dmg;
        hpBar.fillAmount = curHp / maxHp;
        if (curHp<= 0)
        {
            Die();
        }
    }
    public void AddMoney(int amount)
    {
        curMoney +=amount;
        moneyTmp.text = curMoney.ToString();
        
    }

    public void GetHungry(float hunger)
    {
        curHunger -= hunger;
        hungerBar.fillAmount = curHunger/maxHunger;

        if (curHunger <= 0)
        {
            Die();
        }
    }
    private void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void Update()
    {
        GetHungry(hungerLostPerSec * Time.deltaTime);
    }
}
