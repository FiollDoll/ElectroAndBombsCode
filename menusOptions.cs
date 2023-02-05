using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class menusOptions : MonoBehaviour
{

    public void MenuExit(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }

    public void ViewError(Text textError)
    {
        StartCoroutine(TextErrorView(textError));
    }

    private IEnumerator TextErrorView(Text textError)
    {
        // 0.5 - activate, 2 - view, 0.5 - remove
        textError.text = "В ответе/ответах имеются ошибки";
        textError.GetComponent<Animator>().SetBool("view", true);
        yield return new WaitForSeconds(3f);
        textError.GetComponent<Animator>().SetBool("view", false);
        textError.text = "";
    }
}
