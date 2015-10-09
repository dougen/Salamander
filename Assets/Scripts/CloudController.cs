using UnityEngine;

public class CloudController : MonoBehaviour 
{
    public int cloudType;

    private float speed = 0;

	private void Start () 
    {

	}
	
	private void Update () 
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);

        // 当云朵转移到屏幕外时，销毁自身
        if (transform.position.y <= -8f)
        {
            Destroy(gameObject);
        }
	}

    // 重置函数，输入云朵的速度，放大倍数和初始的位置
    public void Reset(float speed, float size, float poxX)
    {
        this.speed = speed;
        transform.localScale = new Vector3(size, size, 1f);
        transform.position = new Vector3(poxX, 8f, -1f);
        gameObject.SetActive(true);
    }
}
