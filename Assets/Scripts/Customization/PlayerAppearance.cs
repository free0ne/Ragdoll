using UnityEngine;

public class PlayerAppearance
{   
    public Color BodyColor;
    public Sprite Eyes;
    public Sprite Mouth;
    public EarsData EarsData;
    public HornData HornData;

    public string EyesPath;
    public string MouthPath;
    public string EarsPath;
    public string HornsPath;
    
    private const string EYES_DIR = "Sprites/Character/Eyes/";
    private const string MOUTHS_DIR = "Sprites/Character/Mouth/";
    private const string EARS_DIR = "Sprites/Character/Ears/";
    private const string HORNS_DIR = "Sprites/Character/Horns/";

    public PlayerAppearance(Color bodyColor, Sprite eyes, Sprite mouth, EarsData earsData, HornData hornData)
    {
        BodyColor = bodyColor;
        Eyes = eyes;
        Mouth = mouth;
        EarsData = earsData;
        HornData = hornData;
    }

    public void BeforeSave()
    {
        EyesPath = EYES_DIR + Eyes.name;
        MouthPath = MOUTHS_DIR + Mouth.name;
        
        EarsPath = EarsData.Sprite == null ? "" : EARS_DIR + EarsData.Sprite.name;
        HornsPath = HornData.Sprite == null ? "" : HORNS_DIR + HornData.Sprite.name;
    }

    public void AfterLoad()
    {
        Eyes = Resources.Load<Sprite>(EyesPath);
        Mouth = Resources.Load<Sprite>(MouthPath);

        if (!string.IsNullOrEmpty(EarsPath))
            EarsData.Sprite = Resources.Load<Sprite>(EarsPath);
        else
            EarsData.Sprite = null;
        
        if (!string.IsNullOrEmpty(HornsPath))
            HornData.Sprite = Resources.Load<Sprite>(HornsPath);
        else
            HornData.Sprite = null;
    }
}
