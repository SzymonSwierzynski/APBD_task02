namespace APBD_TASK2.Models;

public class Camera : Equipment
{
    public int ResolutionMp { get; set; }
    public string LensType { get; set; }

    protected Camera(string name, int resolutionMp, string lensType) : base(name)
    {
        ResolutionMp = resolutionMp;
        LensType = lensType;
    }
}