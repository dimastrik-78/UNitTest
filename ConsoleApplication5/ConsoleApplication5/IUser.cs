using System;

namespace ConsoleApplication5
{
    public interface IUser
    {
        int Balance { get; }
        string Name { get; }
        int Age { get; }
        DateTime DateRegistration { get; }
        string Stocks { get; set; }

        void CheckDate();
    }
}