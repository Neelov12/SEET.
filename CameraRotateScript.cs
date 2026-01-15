using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotateScript : MonoBehaviour
{
    
    public float sensitivity = -1f;
    private float x;
    private float y;
    private Vector3 rotate;
    private GameObject menu;
    private bool isPaused;
    private bool started;

    
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        menu = GameObject.FindGameObjectWithTag("SceneMenu");
        menu.SetActive(false);
        isPaused = false;

        // Camera position
   
        this.transform.position = new Vector3(-8.81f, 0.87f, 9.72f);

        started = true; 
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate camera with mouse movements

        if (isPaused == false)
        {
            y = Input.GetAxis("Mouse X");
            x = Input.GetAxis("Mouse Y");
            rotate = new Vector3(x * (-sensitivity / 2), y * sensitivity, 0);
            transform.eulerAngles = transform.eulerAngles - rotate;
        }

        // Initiate Menu Button 
        if (Input.GetKeyDown("escape") && isPaused == false)
        {
            Cursor.lockState = CursorLockMode.None;
            menu.SetActive(true);
            isPaused = true;
        }
        else if (Input.GetKeyDown("escape") && isPaused == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            menu.SetActive(false);
            isPaused = false;
        }

        // Change camera position based on user input
        this.transform.position = new Vector3(TransferVarScript.x_pos, TransferVarScript.y_pos, TransferVarScript.z_pos);

        /* *** INITIALIZE CAMERA ANGLE FUNCTIONALITY (UNIMPLEMENTED FOR CURRENT PURPOSES) ***
        
        if(TransferVarScript.reset)
        {
            transform.eulerAngles = new Vector3(Mathf.Tan(TransferVarScript.y_pos / TransferVarScript.z_pos) * Mathf.Rad2Deg * -1,
                                                Mathf.Tan(TransferVarScript.x_pos / (3 * TransferVarScript.z_pos)) * Mathf.Rad2Deg * -1,
                                                0);
            TransferVarScript.reset = false;
        */
    }
}
