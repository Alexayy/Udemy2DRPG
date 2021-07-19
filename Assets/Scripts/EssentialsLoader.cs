using UnityEngine;

public class EssentialsLoader : MonoBehaviour
{
    public GameObject UIScreen;
    public GameObject player;

    private void Awake()
    {
        if (UIFade.instance == null)
        {
            UIFade.instance = Instantiate(UIScreen).GetComponent<UIFade>();
        }
        
        if (PlayerController.instance == null)
        {
            var clone = Instantiate(player).GetComponent<PlayerController>();
            PlayerController.instance = clone;
        }
    }
}
