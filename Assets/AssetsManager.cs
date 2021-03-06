using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetsManager : MonoBehaviour
{
    private static AssetsManager _AM;

    public static AssetsManager AM
    {
        get
        {
            if (_AM == null)
            {
                _AM = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<AssetsManager>();
            }
            return _AM;
        }
    }

    public AudioClip lostSound;
    public AudioClip bgm;

}
