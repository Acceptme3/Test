using System.Data;
using Task5.Models.Abstract;

namespace Task5.Models
{
    public class FigureCreator : IFigureCreator
    {
        private readonly ILogger<FigureCreator> _logger;

        public FigureCreator(ILogger<FigureCreator> logger)
        {
            _logger = logger;
        }

        public Figure Create(FigureType figureType, int[] data)
        {
            try
            {
                if (figureType == FigureType.rectangles)
                {
                    return new Rectangle(data[0], data[1]);
                }
                if (figureType == FigureType.circles)
                {
                    return new Circle(data[0]);
                }
                return new Triangle(data[0], data[1], data[2]);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.Message);
                throw new Exception("Внутренняя ошибка. Переданы не валидные данные");
            }
        }
    }
}
