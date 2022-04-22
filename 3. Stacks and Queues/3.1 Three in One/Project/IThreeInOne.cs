namespace Project;

public interface IThreeInOne
{
    public int Pop(int stackIndex);
    public int Push(int stackIndex, int item);
    public int Peek(int stackIndex);
    public bool IsEmpty(int stackIndex);
}

