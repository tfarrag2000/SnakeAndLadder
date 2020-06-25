using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{

    public void OnButtonClick()
    {
        SceneManager.LoadScene("scene 1");
      }

}
