using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class DieByTerrain : MonoBehaviour
{
    [SerializeField] int checkIntervalMilisec;
    int checkFallingInterval;
    int timeCountInWater;
    [SerializeField] int maxCounter;
    //���� ������ �۵�.
    //5�� ���� ī��Ʈ �Ŀ� ���.
    Rigidbody body;
    CancellationTokenSource cancel;

    private void Awake()
    {
        checkFallingInterval = checkIntervalMilisec / 2;
        body = GetComponent<Rigidbody>();
        cancel = new CancellationTokenSource();
    }

    private void Start()
    {
        DelayCheck(CheckFallWater, checkIntervalMilisec);
        DelayCheck(CheckFallingSpeed, checkFallingInterval);

    }

    async void DelayCheck(Action action, int interval)
    {
        try
        {
            await Task.Delay(interval, cancel.Token);
            action();

        }
        catch (OperationCanceledException)
        {
            Debug.Log("ĳ���� ��Ȱ��ȭ�� die �ݺ� üũ �ߴ�.");
        }
    }
    void CheckFallWater()
    {
        if (transform.position.y < 16)
        {
            WaterFallAlert();
        }
        else
            DelayCheck(CheckFallWater, checkIntervalMilisec);
    }
    void CheckFallingSpeed()
    {
        if (body.linearVelocity.y < -9)
        {

            Debug.Log("gameover");
        }
        else
            DelayCheck(CheckFallingSpeed, checkFallingInterval);
    }
    void WaterFallAlert()
    {
        //������ �ٷ� ����������� UI �˸� on
        Debug.Log("�˸�");
        DelayCheck(CheckOutFromWater, checkIntervalMilisec);
    }
    void CheckOutFromWater()
    {
        if (transform.position.y > 16)
        {
            OutFromWaterAlert();
        }
        else
        {
            DelayCheck(CheckOutFromWater, checkIntervalMilisec);
            TimeCountEvent();
        }
    }
    void TimeCountEvent()
    {
        timeCountInWater++;
        if (timeCountInWater > maxCounter)
        {
            Debug.Log("����� �׾����ϴ�.");
        }
    }
    void OutFromWaterAlert()
    {
        timeCountInWater = 0;
        Start();
    }
    private void OnDestroy()
    {
        cancel.Cancel();
    }
}
