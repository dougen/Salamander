using UnityEngine;
using UnityEngine.UI;

public class SpellCoolDown : MonoBehaviour 
{

    public float timer;
    public Text num;
    public Image skill;

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
        // 按下空格键开始进入冷却状态
	    if (Input.GetKeyDown(KeyCode.Space) && skill.fillAmount <= 0)
        {
            skill.fillAmount = 1f;
        }

        // 当开始计时时，显示CD剩余时间
        if (skill.fillAmount <= 1f && skill.fillAmount > 0)
        {
            num.enabled = true;
            skill.fillAmount -= 1f / timer * Time.deltaTime;
            num.text = Mathf.CeilToInt(skill.fillAmount * timer).ToString();
            if (num.text == "0")
            {
                num.enabled = false;
            }
        }
	}
}
