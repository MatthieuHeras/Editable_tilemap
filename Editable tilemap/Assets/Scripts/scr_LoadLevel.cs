using UnityEngine;
using UnityEngine.SceneManagement;

public class scr_LoadLevel : MonoBehaviour
{
    public Animator anim;

    public void load_level()
    {
        anim.Play("anm_ExitingMenu");
    }
    
}
