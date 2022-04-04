using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBound : MonoBehaviour
{
    public GameObject _focus;
    public GameObject _eagle_Cam;
    public float offset = 4.8f;
    public Vector2 Left_Right;
    float CurrentSize = 7.45f;
    float Maximized_Size = 37.5f;
    bool toggleEagle;
    float eagleSpeed = 20f;
    void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            _eagle_Cam.SetActive(true);
            toggleEagle = true;

        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            _eagle_Cam.SetActive(false);
            toggleEagle = false;
            _eagle_Cam.GetComponent<Camera>().orthographicSize = 7.45f;
            
        }
        if (toggleEagle)
        {
            if (_eagle_Cam.GetComponent<Camera>().orthographicSize < Maximized_Size)
            {
              
                _eagle_Cam.GetComponent<Camera>().orthographicSize += eagleSpeed* Time.deltaTime ;
            }
            else
            {
                _eagle_Cam.GetComponent<Camera>().orthographicSize = Maximized_Size;
            }

        }
    }
    // Update is called once per frame
    void LateUpdate()
    {

        if (_focus.transform.position.x < Left_Right.y && _focus.transform.position.x > Left_Right.x)
        {

            transform.position = new Vector3(_focus.transform.position.x, _focus.transform.position.y + offset, transform.position.z);
        }
        if (_focus.transform.position.x >= Left_Right.y)
        {
            transform.position = new Vector3(Left_Right.y, _focus.transform.position.y + offset, transform.position.z);
        }

        if (_focus.transform.position.x <= Left_Right.x)
        {
            transform.position = new Vector3(Left_Right.x, _focus.transform.position.y + offset, transform.position.z);
        }

    }
}
