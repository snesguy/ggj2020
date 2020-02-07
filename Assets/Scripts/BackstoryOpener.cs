using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackstoryOpener : MonoBehaviour
{
    public string Url="https:\\bignoise.neocities.org";

    public void Open()
    {
        Application.OpenURL(Url);
    }
}
