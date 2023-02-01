using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class menusOptions : MonoBehaviour
{
    [SerializeField] private Text _textError;

    public void MenuExit(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }
    
    public void ViewError(string text)
    {
        StartCoroutine(TextErrorView(text));
    }

    private IEnumerator TextErrorView(string errorText)
    {
        // 0.5 - activate, 2 - view, 0.5 - remove
        _textError.text = errorText;
        _textError.GetComponent<Animator>().SetBool("view", true);
        yield return new WaitForSeconds(3f);
        _textError.GetComponent<Animator>().SetBool("view", false);
        _textError.text = "";
    }
}
