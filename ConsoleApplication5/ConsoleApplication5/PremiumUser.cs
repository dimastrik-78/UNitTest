using System;

namespace ConsoleApplication5
{
    public class PremiumUser : IUser
    {
        public PremiumUser(int balance, string name, int age)
        {
            Balance = balance;
            Name = name;
            Age = age;
            DateRegistration = CreateDateRegistration();
        }

        public int Balance { get; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime DateRegistration { get; set; }
        public string Stocks { get; set; }

        private DateTime CreateDateRegistration()
        {
            Random random = new Random();

            return DateTime.MinValue.AddDays(random.Next(1, 32))
                .AddMonths(random.Next(1, 12))
                .AddYears(random.Next(1923, 2024))
                .AddHours(random.Next(0, 24))
                .AddMinutes(random.Next(0, 60))
                .AddSeconds(random.Next(0, 60));
        }
        
        public void CheckDate()
        {
            if (Balance < 0
                || Name.Length <= 3
                || Age < 0)
            {
                throw new Exception("Неправильный ввод данных");
            }
        }
    }
}