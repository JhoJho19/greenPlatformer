using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WheelOfFortune : MonoBehaviour
{
    public Transform wheel; // ������ �� ������ (Transform)
    public float spinDuration = 4.0f; // ������������ ��������
    public float slowDownDuration = 2.0f; // ������������ ����������
    [SerializeField] private Button button;
    private float[] sectorAngles; // ���� ��� ������� �������
    private bool isSpinning = false;

    private void Start()
    {
        // ������������� ����� ��� ������� ������� (360 / 9 = 40 �������� �� ������)
        sectorAngles = new float[9];
        for (int i = 0; i < 9; i++)
        {
            sectorAngles[i] = i * (360 / 9);
        }
    }

    public void StartSpin()
    {
        button.gameObject.SetActive(false);
        if (!isSpinning)
        {
            StartCoroutine(SpinWheel());
        }
    }

    private IEnumerator SpinWheel()
    {
        isSpinning = true;

        float elapsedTime = 0f;
        float currentAngle = wheel.eulerAngles.z;
        float targetAngle = currentAngle + 360 * 5 + Random.Range(0, 360); // 5 ������ �������� ���� ��������� ����

        // �������� ������
        while (elapsedTime < spinDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / spinDuration;
            float angle = Mathf.Lerp(currentAngle, targetAngle, t);
            wheel.eulerAngles = new Vector3(0, 0, angle);
            yield return null;
        }

        // ���������� ��������
        elapsedTime = 0f;
        currentAngle = wheel.eulerAngles.z;
        targetAngle = currentAngle + Random.Range(0, 360); // �������������� ��������� ���� ��� ����������

        while (elapsedTime < slowDownDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / slowDownDuration;
            float angle = Mathf.Lerp(currentAngle, targetAngle, t);
            wheel.eulerAngles = new Vector3(0, 0, angle);
            yield return null;
        }

        // ��������� �� ��������� �������
        float finalAngle = wheel.eulerAngles.z;
        int sector = GetSector(finalAngle);
        Debug.Log("Landed on sector: " + sector);

        isSpinning = false;
    }

    private int GetSector(float angle)
    {
        angle = Mathf.Repeat(angle, 360); // ���������� ���� � ��������� [0, 360)
        float sectorSize = 360 / 9;

        for (int i = 0; i < sectorAngles.Length; i++)
        {
            if (angle >= sectorAngles[i] && angle < sectorAngles[i] + sectorSize)
            {
                return i + 1; // ���������� ����� ������� (1-9)
            }
        }

        return 1; // �� ������ ������ ���������� ������ 1
    }
}
