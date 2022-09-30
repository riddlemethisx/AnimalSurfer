using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTexture : MonoBehaviour
{
    //BU KOD ATANAN OBJEDEK� TEXTURE'I 90 DERECE D�ND�R�R

    void Start()
    {
        Texture2D rotatedTexture = rotateTexture(gameObject.GetComponent<MeshRenderer>().material.GetTexture("_MainTex") as Texture2D, true);
        gameObject.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", rotatedTexture);
    }

    void Update()
    {
        
    }








    Texture2D rotateTexture(Texture2D originalTexture, bool clockwise)
    {
        Color32[] original = originalTexture.GetPixels32();
        Color32[] rotated = new Color32[original.Length];
        int w = originalTexture.width;
        int h = originalTexture.height;

        int iRotated, iOriginal;

        for (int j = 0; j < h; ++j)
        {
            for (int i = 0; i < w; ++i)
            {
                iRotated = (i + 1) * h - j - 1;
                iOriginal = clockwise ? original.Length - 1 - (j * w + i) : j * w + i;
                rotated[iRotated] = original[iOriginal];
            }
        }

        Texture2D rotatedTexture = new Texture2D(h, w);
        rotatedTexture.SetPixels32(rotated);
        rotatedTexture.Apply();
        return rotatedTexture;
    }



}
