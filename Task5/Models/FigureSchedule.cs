namespace Task5.Models
{
    public static class FigureSchedule
    {
        public static List<int[]> rectangles = new List<int[]>
            {
                new int[] { 1, 4 },
                new int[] { 4, 56 },
                new int[] { 55, 16 },
                new int[] { 44, 2 },
                new int[] { 8, 8 },
                new int[] { 102, 87 },
                new int[] { 6, 13 },
                new int[] { 8, 22 },
                new int[] { 23, 10 },
                new int[] { 9, 100 }
            };

        public static List<int[]> triangles = new List<int[]>
            {
                new int[] { 10, 4, 8 },
                new int[] { 4, 7, 7 },
                new int[] { 13, 16, 8 },
                new int[] { 22, 34, 33 },
                new int[] { 8, 8, 9 },
                new int[] { 102, 87, 103 },
                new int[] { 6, 13, 8 },
                new int[] { 8, 22, 15 },
                new int[] { 23, 16, 9 },
                new int[] { 78, 100, 50 }
            };

        public static List<int[]> circles = new List<int[]>
            {
                new int[] { 4 },
                new int[] { 55 },
                new int[] { 94 },
                new int[] { 45 },
                new int[] { 89 },
                new int[] { 12 },
                new int[] { 14 },
                new int[] { 32 },
                new int[] { 313 },
                new int[] { 77 }
            };


        public static int[] GetValidData(FigureType figureType)
        {
            Random random = new Random();

            if (figureType == FigureType.rectangles)
            {             
                return rectangles[random.Next(0, rectangles.Count())];
            }
            if (figureType == FigureType.triangles)
            {
                return triangles[random.Next(0, triangles.Count())];
            }
                return circles[random.Next(0, circles.Count())];        
        }
    }
    public enum FigureType
    {
        rectangles,
        triangles,
        circles
    }
}
