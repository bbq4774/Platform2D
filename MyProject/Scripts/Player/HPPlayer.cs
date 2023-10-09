using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HPPlayer : MonoBehaviour
{
    private static HPPlayer instance;
    public static HPPlayer Instance => instance;

    [SerializeField] private int maxHP = 3;
    [SerializeField] private int hp = 3;
    private bool isDie;
    public bool IsDie => isDie;

    [Header("Invisible Info")]
    [SerializeField] private float timeInvisible = 1f;
    [SerializeField] private float countTime = 0;

    private void Awake()
    {
        HPPlayer.instance = this;
    }

    private void Update()
    {
        CanDeduct();
        CanAddHp();
        CheckIsDie();
    }

    public bool CanAddHp()
    {
        return (hp < maxHP);
    }

    public void AddHP()
    {
        if (hp == maxHP) return;

        hp++;
        HeartManagement.Instance.AbleObj();
    }

    private bool CanDeduct()
    {
        countTime += Time.deltaTime;

        if (countTime >= timeInvisible)
            return true;
        return false;
    }

    public void DeductHP()
    {
        if (hp == 0) return;
        if (!CanDeduct()) return;

        countTime = 0; 
        hp--;

        HeartManagement.Instance.DisableObj();
        PlayerControl.Instance.IsHitting();
    }

    private void CheckIsDie()
    {
        isDie = (hp <= 0);
        if (isDie)
            Invoke(nameof(ReloadLevel), 1f);
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
