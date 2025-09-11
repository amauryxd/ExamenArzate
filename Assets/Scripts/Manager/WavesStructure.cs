[System.Serializable]
public class WavesStructure
{
    public WaveStructure[] waveStructures;
}
[System.Serializable]
public class WaveStructure
{
    public int wave;
    public Enemys[] enemysStructure;
}
[System.Serializable]
public class Enemys
{
    public int enemyType;
    public float time;
}
