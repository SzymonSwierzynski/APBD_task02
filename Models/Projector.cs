namespace APBD_TASK2.Models;

public class Projector : Equipment
{
    public int Lumens { get; set; }
    public double ContrastRatio { get; set; }

    protected Projector(string name, int lumens, double contrastRatio) : base(name)
    {
        Lumens = lumens;
        ContrastRatio = contrastRatio;
    }
}