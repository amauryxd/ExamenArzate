[System.Serializable]
public class WaveData
{
    public Waves[] Waves;
}
[System.Serializable]
public class Waves
{
    public int Wave;
    public Enemies[] Enemies;
}
[System.Serializable]
public class Enemies
{
    public int Enemy;
    public float Time;
}
