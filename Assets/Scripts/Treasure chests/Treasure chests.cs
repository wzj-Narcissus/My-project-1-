using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Treasurechests : MonoBehaviour
{


    public float speed;//初始速度
    public float damage;//野猪初始攻击力
    public float health;//生命
    public float maxHealth;//最大生命
    public float criticalStrikeRate;//初始暴击率
    public float missRate;//初始闪避率
    public float shield;//护盾
    public float damageMulti = 1;//伤害倍率
    public float hurtMulti = 1;//受伤倍率


    public string nextname;

    public Button buttons;


    private struct Buffs
    {
        public string sometext;
        public string name;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
