using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadows : MonoBehaviour
{
    private float cursorRadius = 1.5f;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<InputManager>().inFreezeTime)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (mouseInCircle())
                {
                    RaycastHit2D hit = Physics2D.Raycast(gameObject.GetComponent<Transform>().position, new Vector2(0,-1));
                    player.GetComponent<Transform>().position = 
                    new Vector2(gameObject.GetComponent<Transform>().position.x, 0.7217519f + -hit.distance + gameObject.GetComponent<Transform>().position.y);
                    player.GetComponent<InputManager>().inFreezeTime = false;
                }
            }
        }
    }

    private bool mouseInCircle()
    {   
        
        Vector3 mousPos3D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mPos = new Vector2(mousPos3D.x,mousPos3D.y); 
        if (Vector2.Distance(mPos, gameObject.GetComponent<Transform>().position) <= cursorRadius)
        {
            Debug.Log("I am in the circle");
            return true;
        }
        else
        {
            Debug.Log("I am not in the circle");
            return false;
        }
    }
}
