using UnityEngine;

public class manager : MonoBehaviour
{
    public static manager manger;
    public  int selectedcolor;
    public GameObject[] Colors;
    public GameObject[] items;
    private void Awake()
    {
        manger = this;
        selectedcolor = Random.Range(0, Colors.Length);
        //voor de Kameleon    1 = groen   -   2 = oranje   -   3 = rood

        //voor de items       1 = groen   -   2 = oranje   -   3 = rood   -   4 = blauw
    }

}
