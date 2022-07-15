namespace DeathCalculator.Service
{
    public class DeathCalculatorService : IDeathCalculatorService
    {
        #region (public) Methods

        public double GetAverageKilledPerson(int AgeOfDeathA, int YearOfDeathA, int AgeOfDeathB, int YearOfDeathB)
        {
            Person personA = new Person()
            {
                AgeOfDeath = AgeOfDeathA,
                YearOfDeath = YearOfDeathA
            };

            Person personB = new Person()
            {
                AgeOfDeath = AgeOfDeathB,
                YearOfDeath = YearOfDeathB
            };

            double average = (personA.GetNumberOfKilledOnYearBorn() + personB.GetNumberOfKilledOnYearBorn()) / 2;

            return average;
        }

        public bool IsValidData(int AgeOfDeathA, int YearOfDeathA, int AgeOfDeathB, int YearOfDeathB)
        {
            return AgeOfDeathA > 0 && YearOfDeathA > 0 && AgeOfDeathB > 0 && YearOfDeathB > 0;
        }

        #endregion
    }
}