namespace Task4.Models
{
    public static class TrainSchedule
    {
        public static Train[] trains = new Train[]
        {
            new Train(){TownTo = "Москва",
                        Number = 5,
                        DepartureTime = new TimeOnly(17,0)},
            new Train(){TownTo = "Анапа",
                        Number = 1,
                        DepartureTime = new TimeOnly(11,30)},
            new Train(){TownTo = "Саратов",
                        Number = 8,
                        DepartureTime = new TimeOnly(9,0)},
            new Train(){TownTo = "Мурманск",
                        Number = 15,
                        DepartureTime = new TimeOnly(22,20)},
            new Train(){TownTo = "Екатеринбург",
                        Number = 4,
                        DepartureTime = new TimeOnly(11,0)},
        };

    }
}
