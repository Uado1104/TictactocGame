using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessPiece : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtPiece;
    public Button btnPiece;
    public int[] PieceIndex;
    void Start()
    {
        
    }
    public void UpdateInfo(string info)
    {
        txtPiece.text = info;
    }
}
