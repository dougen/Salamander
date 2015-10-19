using UnityEngine;
using UnityEngine.UI;

public class SpellCoolDown : MonoBehaviour 
{

    public float timer;
    public Text num;
    public Image skill;

    [HideInInspector]
    public bool isCD = false;     // 默认技能无CD

	// Use this for initialization
	private void Start () 
    {
        // 初始时，CD数字不显示。
        if (num.enabled)
        {
            num.enabled = false;
        }
	}
	
	// Update is called once per frame
	private void Update () 
    {
        // 当开始计时时，显示CD剩余时间
        if (skill.fillAmount <= 1f && skill.fillAmount > 0)
        {
            num.enabled = true;
            skill.fillAmount -= 1f / timer * Time.deltaTime;
            num.text = Mathf.CeilToInt(skill.fillAmount * timer).ToString();
            if (num.text == "0")
            {
                num.enabled = false;        // CD数字消失
                isCD = false;               // CD时间结束
            }
        }
	}

    public void Spell()
    {
        if (isCD == false)
        {
            skill.fillAmount = 1f;
            isCD = true;
        }
    }
}
