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
    //물에 빠지면 작동.
    //5초 정도 카운트 후에 사망.
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
            Debug.Log("캐릭터 비활성화로 die 반복 체크 중단.");
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
        //물에서 바로 빠져나오라는 UI 알림 on
        Debug.Log("알림");
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
            Debug.Log("당신은 죽었습니다.");
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
