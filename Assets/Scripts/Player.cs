using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject rain;
    public string[] storytext = new string[5];

    public Text text;
    public GameObject image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        text.text = "지금은 날씨가 맑고, \n계곡에서 친구들과 놀고 있습니다.";
        
        //storytext[1] = "\n하지만 이곳은 아주 위험한 상황에 놓일 수도 있습니다.\n주변을 AR로 둘러보며 안전한 장소를 미리 파악해 보세요.";
       // storytext[2] = "계곡에서 머리로 빠지는 다이빙은 아주 위험합니다!";
       // storytext[3] = "물의 깊이와 물살을 확인합니다!";
        //storytext[4] = "비가 오기 시작했습니다.\n비가 오면 계곡이 범람할 수 있습니다.\n빨리 안전한 장소로 이동하세요.";
        StartCoroutine("nextText");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            rain.SetActive(true);
        }
    }

    IEnumerator nextText()
    {
        yield return new WaitForSeconds(2f);
        text.text = "\n하지만 이곳은 아주 위험한 상황에 놓일 수도 있습니다.\n주변을 위험한 상황을 파악해 보세요.";
        yield return new WaitForSeconds(2f);

        text.text = "";
        image.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Trigger Entered: " + other.gameObject.name);
        if (other.CompareTag("SafeZone"))
        {
            image.SetActive(true);
            text.text = "안전하게 탈출을 성공하였습니다!";
           StartCoroutine("final");
        }
        if(other.CompareTag("Issue1"))
        {
            image.SetActive(true);
            text.text = "계곡에서 머리로 빠지는 다이빙은 아주 위험합니다!";
            StartCoroutine("clear");
        }
        if(other.CompareTag("Issue2"))
        {
            image.SetActive(true);
            text.text = "물의 깊이와 물살을 확인합니다!";
            StartCoroutine("rainStart");
        }
    }

    IEnumerator clear()
    {
        yield return new WaitForSeconds(2f);

        text.text = "";
        image.SetActive(false);
    }

    IEnumerator rainStart()
    {
        yield return new WaitForSeconds(2f);
        rain.SetActive(true);

        text.text = "비가 오기 시작했습니다.\n비가 오면 계곡이 범람할 수 있습니다.\n빨리 안전한 장소로 이동하세요.";

        yield return new WaitForSeconds(1f);
        image.SetActive(false);
        text.text = "";

    }

    IEnumerator final()
    {
        rain.SetActive(false);
        yield return new WaitForSeconds(2f);
        text.text = "만약 탈출하지 못했다면 \n물이 범람하여 위험한 상황에 빠졌슬 것입니다.";

        yield return new WaitForSeconds(2f);

        text.text = "안전한 장소를 미리 파악하는 것이 중요합니다.";
    }
}
