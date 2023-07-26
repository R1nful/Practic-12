using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Practic_12
{
    internal class Invoice : INotifyPropertyChanged
    {
        private bool isOpen = true;
        private decimal balance;

        public string Number { get; }

        public string Owner { get;}

        public decimal Balance {
            get { 
                return balance;
            }
        }

        public bool IsOpen { 
            get 
            {
                return isOpen;
            }
        }

        public Invoice(string number, string owner, decimal _balance) {
        
            Number = number;
            Owner = owner;
            balance = _balance;
        }

        /// <summary>
        /// Переводит деньги из этого счета на другой
        /// </summary>
        /// <param name="trensferInvoice">Счет для перевода</param>
        /// <param name="trensferMoney">Сумма перевода</param>
        public void TransferMoney(ref Invoice trensferInvoice, decimal trensferMoney)
        {
            if (isOpen && trensferInvoice.IsOpen)
            {
                if(balance >= trensferMoney)
                {
                    balance -= trensferMoney;
                    trensferInvoice.AddBalanse(trensferMoney);
                    OnPropertyChanged("Balance");
                }
            }
        }

        /// <summary>
        /// Добавляет заданное количество денег на баланс
        /// </summary>
        /// <param name="sum"></param>
        private void AddBalanse(decimal sum)
        {
            balance += sum;
            OnPropertyChanged("balance");
        }

        /// <summary>
        /// Меняет значение поля isOpne на противоположное 
        /// </summary>
        public void ChangeOpen()
        {
            isOpen = !isOpen;
            OnPropertyChanged("isOpen");
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
