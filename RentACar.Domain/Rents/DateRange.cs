namespace RentACar.Domain.Rents
{
    public sealed record DateRange
    {
        private DateRange()
        {

        }

        public DateOnly Start { get; init; }
        public DateOnly Finish { get; init; }

        public int QuantityDays => Finish.DayNumber - Start.DayNumber;
        public static DateRange Create(DateOnly start, DateOnly finish)
        {
            if (finish > start)
            {
                throw new ApplicationException("La fecha del final es menor que la de inicio");
            }

            return new DateRange()
            {
                Start = start,
                Finish = finish
            };
        }

    }
}
