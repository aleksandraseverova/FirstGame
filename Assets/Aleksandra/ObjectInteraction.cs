using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{
    //public GameObject canvas;
    //public Text displayText;

    //private void Start()
    //{
    //canvas.SetActive(false);
    //}

    private void Update()
    {
        // Use inline conditional to determine input position based on platform
        Vector3 inputPosition = (Input.touchCount > 0) ? Input.GetTouch(0).position : (Vector3)Input.mousePosition;

        // Raycast to determine if the touch or click hits the object
        Ray ray = Camera.main.ScreenPointToRay(inputPosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
        // Activate the canvas and set the text
        // canvas.SetActive(true);
        //displayText.text = "Your message here!";
            SceneManager.LoadScene("forest");
     
        }

    //private void OnCollisionEnter(Collision collision)
    //{
       
    }
}