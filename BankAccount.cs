using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba10
{
    public enum TypeOfAccount
    {
        DEBIT,
        CREDIT,
        DEPOSIT
    }
    public class BankAccount
    {
        protected int _number;
        protected decimal _balance;
        protected TypeOfAccount _typeAccount;
        static int _counter = 1;
        public BankAccount()
        {
            _number = Increase();
        }
        public BankAccount(decimal balance)
        {
            _balance = balance;
            _number = Increase();
        }
        public BankAccount(TypeOfAccount typeAccount)
        {
            _typeAccount = typeAccount;
            _number = Increase();
        }

        public int Increase()
        {
            return _counter++;
        }

        public int accountNumber
        {
            get { return _number; }
            set { _number = value; }
        }
        public decimal accountBalance
        {
            get { return _balance; }
            set { _balance = value; }
        }
        public TypeOfAccount accountType
        {
            get { return _typeAccount; }
            set { _typeAccount = value; }
        }
        public BankAccount(decimal balance, TypeOfAccount typeAccount)
        {
            _balance = balance;
            _typeAccount = typeAccount;
            _number = Increase();
        }
        public void TransferMoney(ref BankAccount transferAccaunt, int amount)
        {
            if (transferAccaunt.accountBalance >= amount)
            {
                transferAccaunt.accountBalance -= amount;
                this.accountBalance += amount;
            }
        }
    }
}
