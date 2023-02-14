using System;
using System.Collections.Generic;

namespace ConsoleApplication5
{
    public class WorkWithUser
    {
        private readonly List<IUser> _users;

        private int[] _indexUserAgeArray = { -1, -1, -1 };
        private int[] _indexUserDateArray = { -1, -1, -1, -1, -1 };

        public WorkWithUser(List<IUser> users)
        {
            _users = users;
        }
        
        public void UserName(string userName)
        {
            if (Check(userName))
            {
                for (int i = 0; i < _users.Count; i++)
                {
                    if (_users[i].Name == userName)
                    {
                        if ((Type)_users[i] == typeof(PremiumUser))
                        {
                            Login(_users[i] as PremiumUser);

                            FirstUsers();
                        }
                        else
                        {
                            Login(_users[i] as RegularUser);
                            
                            JuniorUsers();
                        }
                    }
                }
            }
            else
            {
                throw new Exception($"Нет User с именем {userName}");
            }
        }
        
        public void Stocks(IUser user)
        {
            if (Check(user))
            {
                user.Stocks = "Акции есть(какие не важны)";
            }
            else
            {
                user.Stocks = null;
            }
        }

        private bool Check(IUser user)
        {
            return user.Balance >= 0
                   && user.Name.Length > 3
                   && user.Age >= 0;
        }

        private bool Check(string userName)
        {
            for (int i = 0; i < _users.Count; i++)
            {
                if (_users[i].Name == userName)
                {
                    return true;
                }
            }

            return false;
        }
        
        private void Login(PremiumUser premiumUser)
        {
            Console.WriteLine($"Здравствуйте дрогой пользователь, мы вас ждали \n Ваш баланс {premiumUser.Balance}");
            
            if (premiumUser.Age < 18)
            {
                Console.WriteLine($"аши акции {premiumUser.Stocks}");
            }
        }
        
        private void Login(RegularUser regularUser)
        {
            Console.WriteLine($"Здравствуйте. \n Ваш баланс {regularUser.Balance}");
            
            if (regularUser.Age < 18)
            {
                Console.WriteLine($"аши акции {regularUser.Stocks}");
            }
        }

        private void FirstUsers()
        {
            DateTime minDateUser = DateTime.MaxValue;
            int indexUser = -1;
            
            for (int i = 0; i < _users.Count; i++)
            {
                if ((Type)_users[i] == typeof(PremiumUser))
                {
                    if (_users[i].DateRegistration < minDateUser)
                    {
                        minDateUser = _users[i].DateRegistration;
                        indexUser = i;
                    }
                }
            }

            if (_indexUserDateArray[0] == -1)
            {
                _indexUserDateArray[0] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
            else if(_indexUserDateArray[1] == -1)
            {
                _indexUserDateArray[1] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
            else if (_indexUserDateArray[2] == -1)
            {
                _indexUserDateArray[2] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
            else if (_indexUserDateArray[3] == -1)
            {
                _indexUserDateArray[3] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
            else if (_indexUserDateArray[4] == -1)
            {
                _indexUserDateArray[4] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
        }

        private void JuniorUsers()
        {
            int minAgeUser = Int32.MaxValue;
            int indexUser = -1;
            
            for (int i = 0; i < _users.Count; i++)
            {
                if ((Type)_users[i] == typeof(RegularUser))
                {
                    if (_users[i].Age < minAgeUser)
                    {
                        minAgeUser = (int)_users[i].Age;
                        indexUser = i;
                    }
                }
            }

            if (_indexUserAgeArray[0] == -1)
            {
                _indexUserAgeArray[0] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
            else if(_indexUserAgeArray[1] == -1)
            {
                _indexUserAgeArray[1] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
            else if (_indexUserAgeArray[2] == -1)
            {
                _indexUserAgeArray[2] = indexUser;
                Stocks(_users[indexUser]);
                
                Console.WriteLine($"Предлагаем вам акции {_users[indexUser].Stocks}");
            }
        }
    }
}