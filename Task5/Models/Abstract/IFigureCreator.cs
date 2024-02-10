namespace Task5.Models.Abstract
{
    public interface IFigureCreator
    {
        Figure Create(FigureType type, int[] data);
    }
}