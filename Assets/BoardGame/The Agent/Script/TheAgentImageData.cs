using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "TheAgentImageData", menuName = "The Agent/Image Data")]
public class TheAgentImageData : ScriptableObject 
{
    public Image categoryImage;

    public List<Sprite> imageLocation = new List<Sprite>();
}
