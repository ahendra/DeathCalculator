namespace DeathCalculator.Service
{
    public class Person
    {
        #region Properties

        public int YearOfDeath { get; set; }
        public int AgeOfDeath { get; set; }

        #endregion

        #region (public) Methods

        public double GetNumberOfKilledOnYearBorn()
        {
            int personBornYear = YearOfDeath - AgeOfDeath;
            double numberOfKilledOnYearBorn = calculateSumFibo(personBornYear);

            return numberOfKilledOnYearBorn;
        }

        #endregion

        #region (private) Methods

        private int calculateSumFibo(int n)
        {
            if (n <= 0)
                return 0;

            int[] fibo = new int[n + 1];
            fibo[0] = 0; fibo[1] = 1;

            int sum = fibo[0] + fibo[1];

            for (int i = 2; i <= n; i++)
            {
                fibo[i] = fibo[i - 1] + fibo[i - 2];
                sum += fibo[i];
            }

            return sum;
        }

        #endregion
    }
}