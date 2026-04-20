using UnityEngine;
using UnityEngine.SceneManagement;

public class scenechanger : MonoBehaviour
{
   
   public string scenceToLoad;




   public void ChangeSceneNow()
   {
    SceneManager.LoadScene(scenceToLoad);
   }
}
