using UnityEngine;

public class scr_ModifyState : MonoBehaviour
{
    private GameObject thing;

    public void enableGameObject(string name)
    {
        thing = GameObject.Find(name);
        thing.SetActive(true);
    }
    public void disableGameObject(string name)
    {
        thing = GameObject.Find(name);
        thing.SetActive(false);
    }
}
