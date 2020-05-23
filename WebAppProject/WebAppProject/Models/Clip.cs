using System;

public class Clip : Item
{

    private int size;

    private string path;

    public Clip(string path)
    {
        this.Path = path;
    }
    #region
    public int Size { get => size; set => size = value; }
    public string Path { get => path; set => path = value; }
    #endregion
    public void display() { }
}
