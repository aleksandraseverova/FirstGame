using UnityEngine;
using UnityEngine.SceneManagement;


public class Inv_Collected : MonoBehaviour
{
    public string name;
    public Sprite image;
    private Inv_Inventory inventory;

    private void Start()
    {
        inventory = FindObjectOfType<Inv_Inventory>();
    }

    private void OnTriggerEnter(Collider other)
    {                 
        inventory.AddItem(image, name, gameObject);
        SceneManager.LoadScene("forest");
    }

}
