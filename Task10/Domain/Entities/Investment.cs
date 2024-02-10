namespace Task10.Domain.Entities
{
    public class Investment : EntityBase
    {
        public int CountMonth { get; set; }
        public int Deposit { get; set; }
        public int TotalDeposit { get; set; }
        public Investment()
        {
            CountMonth = 0;
            Deposit = 0;
        }
    }
}
