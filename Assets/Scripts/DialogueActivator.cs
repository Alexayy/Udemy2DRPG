using UnityEngine;

public class DialogueActivator : MonoBehaviour
{
    public string[] lines;

    private bool _canActivate;

    public bool isPerson = true;

    private void Update()
    {
        if (_canActivate && Input.GetButtonDown("Fire1") && !DialogManager.instance.dialogueBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines, isPerson);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _canActivate = false;
        }
    }
}
