using UnityEngine;

public class CamoMiniGame : MonoBehaviour
{
    [SerializeField] int amount = 0;
    [SerializeField] Animator anim;
    [SerializeField] GameObject canvas;
    public enum Colorss
    {
        Green,
        Blue,
        Brown,
        Red
    }

    public  Colorss camoColor;


    private void Start()
    {
        camoColor = Colorss.Green;
    }


    public void UpdateCamoAmountGreen()
    {
        if (camoColor == Colorss.Green)
        {
            amount += 1;
            camoColor = Colorss.Blue;
            anim.SetTrigger("blue");
        }
    }

    public void UpdateCamoAmountBlue()
    {
        if (camoColor == Colorss.Blue)
        {
            amount += 1;
            camoColor = Colorss.Brown;
            anim.SetTrigger("brown");
        }
    }

    public void UpdateCamoAmoundBrown()
    {
        if(camoColor == Colorss.Brown)
        { 
            amount += 1;
            camoColor = Colorss.Red;
            anim.SetTrigger("red");
        }
    }

    public void UpdateCamoAmountRed()
    {
        if( camoColor == Colorss.Red)
        {
            amount += 1;
            //zet hier het canvas uit en zet aan dat je nu het masker hebt
            Destroy(canvas, 1f);
        }
        
    }

    
}
