namespace Task4.Models
{
    public struct Train
    {
        public string TownTo { get; set; }
        public int Number {  get; set; }
        public TimeOnly DepartureTime { get; set; }

        public Train(string townTo, int number, TimeOnly departTime ) 
        {
            TownTo = townTo;
            Number = number;
            DepartureTime = departTime;
        }
    }
}
