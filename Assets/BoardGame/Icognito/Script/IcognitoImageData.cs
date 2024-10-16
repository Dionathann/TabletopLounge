using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Icognito Image Data", menuName = "Icognito / Icognito Image Data")]
public class IcognitoImageData : ScriptableObject
{
    public List<Sprite> iconList = new List<Sprite>();
    public List<Sprite> categoryList = new List<Sprite>();
}
