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
        text.text = "������ ������ ����, \n���� ģ����� ��� �ֽ��ϴ�.";
        
        //storytext[1] = "\n������ �̰��� ���� ������ ��Ȳ�� ���� ���� �ֽ��ϴ�.\n�ֺ��� AR�� �ѷ����� ������ ��Ҹ� �̸� �ľ��� ������.";
       // storytext[2] = "���� �Ӹ��� ������ ���̺��� ���� �����մϴ�!";
       // storytext[3] = "���� ���̿� ������ Ȯ���մϴ�!";
        //storytext[4] = "�� ���� �����߽��ϴ�.\n�� ���� ����� ������ �� �ֽ��ϴ�.\n���� ������ ��ҷ� �̵��ϼ���.";
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
        text.text = "\n������ �̰��� ���� ������ ��Ȳ�� ���� ���� �ֽ��ϴ�.\n�ֺ��� ������ ��Ȳ�� �ľ��� ������.";
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
            text.text = "�����ϰ� Ż���� �����Ͽ����ϴ�!";
           StartCoroutine("final");
        }
        if(other.CompareTag("Issue1"))
        {
            image.SetActive(true);
            text.text = "���� �Ӹ��� ������ ���̺��� ���� �����մϴ�!";
            StartCoroutine("clear");
        }
        if(other.CompareTag("Issue2"))
        {
            image.SetActive(true);
            text.text = "���� ���̿� ������ Ȯ���մϴ�!";
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

        text.text = "�� ���� �����߽��ϴ�.\n�� ���� ����� ������ �� �ֽ��ϴ�.\n���� ������ ��ҷ� �̵��ϼ���.";

        yield return new WaitForSeconds(1f);
        image.SetActive(false);
        text.text = "";

    }

    IEnumerator final()
    {
        rain.SetActive(false);
        yield return new WaitForSeconds(2f);
        text.text = "���� Ż������ ���ߴٸ� \n���� �����Ͽ� ������ ��Ȳ�� ������ ���Դϴ�.";

        yield return new WaitForSeconds(2f);

        text.text = "������ ��Ҹ� �̸� �ľ��ϴ� ���� �߿��մϴ�.";
    }
}
