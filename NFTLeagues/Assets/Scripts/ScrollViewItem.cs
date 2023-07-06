using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollViewItem : MonoBehaviour
{
    [SerializeField] 
    private RawImage childImage;

    public void ChangeImage(Texture2D image)
    {
        childImage.texture = image;
        childImage.texture.filterMode = FilterMode.Point;
    }
}
