namespace DeathCalculator.Service
{
    public interface IDeathCalculatorService
    {
        #region (public) Methods

        double GetAverageKilledPerson(int AgeOfDeathA, int YearOfDeathA, int AgeOfDeathB, int YearOfDeathB);
        bool IsValidData(int AgeOfDeathA, int YearOfDeathA, int AgeOfDeathB, int YearOfDeathB);

        #endregion
    }
}