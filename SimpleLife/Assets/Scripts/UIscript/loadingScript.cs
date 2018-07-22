using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class loadingScript : MonoBehaviour {
	private AsyncOperation async;
	public GameObject loading;
	public GameObject loadingImage;
	public Text loadingText;

    public IEnumerator LoadLevelWithBar (string levelName)
    {
        async = SceneManager.LoadSceneAsync(levelName);
        while (!async.isDone)
        {
            loadingImage.GetComponent<Image>().fillAmount = async.progress;
			loadingText.text = ""+(int)((async.progress)*100)+"%";
			if(async.isDone){
				loading.SetActive(false);
				var clone1 = FindObjectOfType<CameraControler>();
				clone1.offset = new Vector2(0,0);
			}
            yield return null;
        }
    }
}
