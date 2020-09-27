using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public float slowdownLength = 2;

    public float speedUpFactor = 2f;
    public float speedUpLength = 2;

    bool slowDown;
    bool speedUp;

    void Update()
    {
        if (slowDown)
        {
            Time.timeScale += (1f / slowdownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0, 1);
        }
        else if (speedUp)
        {
            Time.timeScale += (1f / speedUpLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 1, 2);
        }
        
    }

    public void DoSlowmotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        slowDown = true;
        speedUp = false;
    }

    public void SpeedUpTime()
    {
        Time.timeScale = speedUpFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        speedUp = true;
        slowDown = false;
    }
}
