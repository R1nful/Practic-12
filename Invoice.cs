﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Principal;
using System.Transactions;
using System.Windows;
namespace Practic_12
{

    internal class Invoice : INotifyPropertyChanged, ITransaction<decimal>, IAccount<Invoice>
    {
        static long num;

        static Invoice()
        {
            num = 1;
        }

        private bool isOpen;

        private decimal balance;

        public long Number { get; }

        public string Owner { get; }

        public string TypeInvoice { get; }

        public decimal Balance
        {
            get
            {
                return balance;
            }
        }

        public bool IsOpen
        {
            get
            {
                return isOpen;
            }
        }

        public Invoice(string owner, decimal balance, bool isOpen, string typeInvoice, long number = -1)
        {
            this.Owner = owner;
            this.balance = balance;
            this.isOpen = isOpen;
            this.TypeInvoice = typeInvoice;

            if(number>-1)
                this.Number = number;
            else 
                this.Number = num;

            num++;
        }

        /// <summary>
        /// Переводит деньги из этого счета на другой
        /// </summary>
        /// <param name="trensferInvoice">Счет для перевода</param>
        /// <param name="trensferMoney">Сумма перевода</param>
        public Invoice TransferMoney(Invoice trensferInvoice, decimal trensferMoney)
        {
            if (isOpen && trensferInvoice.IsOpen)
            {
                if (balance >= trensferMoney)
                {
                    balance -= trensferMoney;
                    trensferInvoice.AddBalanse(trensferMoney);
                    OnPropertyChanged("Balance");
                }
                else
                {
                    MessageBox.Show("Перевод невозможен. Недостаточно Средств");
                }
            }
            else
            {
                MessageBox.Show("Перевод невозможен. Счет закрыт");
            }
            return trensferInvoice;
        }

        /// <summary>
        /// Добавляет заданное количество денег на баланс
        /// </summary>
        /// <param name="sum"></param>
        public void AddBalanse(decimal sum)
        {
            if (isOpen)
            {
                balance += sum;
                OnPropertyChanged("balance");
            }
            else
                MessageBox.Show("Пополнение невозможно. Счет закрыт");
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
