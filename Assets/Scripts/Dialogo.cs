using UnityEngine;

public enum Emotion
{
    None,
    Happy,
    Angry,
    Scared,
}

public class Dialogo
{
    public string texto;
    public Emotion emotion;

    public string GetDialog()
    {
        return texto + " [" + emotion.ToString() + "]";
    }
}