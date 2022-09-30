using UnityEngine;

public class FinishTrigger : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject levelCompleteCamera;

  

    public GameObject levelCompleteMenu;

    

    private void Start()
    {
        levelCompleteCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {

            levelCompleteMenu.SetActive(true);

            mainCamera.SetActive(false);
            levelCompleteCamera.SetActive(true);
        }
    }
}
