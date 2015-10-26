using UnityEngine;

public class FireScripts : MonoBehaviour 
{

	// Use this for initialization
	private void Start () 
    {
	
	}
	
	// Update is called once per frame
	private void Update () 
    {
	
	}

    public void DestoryPlayer()
    {
        GameObject player = transform.parent.gameObject;
        player.SetActive(false);
    }
}
