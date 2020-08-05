using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    //插值: 取的兩點中間直
    //A:0
    //B:10
    //取得A與B中間50%值
    //插植(A,B,0.5f)=5

    public float A = 0;
    public float B = 100;

    private void Start()
    {
        float result = Mathf.Lerp(A, B, 0.5f);
        print(result);
    }

    public float C = 0;
    public float D = 100;

    public Vector2 v2A = new Vector2(0, 0);
    public Vector2 v2B = new Vector2(100, 100);

    public Color ca = new Color(0, 0, 0);
    public Color cb = new Color(0.5f, 0.1f, 0.3f);

    private void Update()
    {
        C = Mathf.Lerp(C, D, 0.5f * Time.deltaTime);

        v2A = Vector2.Lerp(v2A, v2B, 0.7f * Time.deltaTime);

        ca = Color.Lerp(ca, cb, 0.6f * Time.deltaTime);






    }

}
