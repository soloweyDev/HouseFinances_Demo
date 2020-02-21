namespace HouseFinances
{
    public sealed class MonthBalance : DataProperty
    {
        private string oldMonth;
        private string incoming;
        private string expense;
        private string balance;

        public string OldMonth
        {
            get => oldMonth;
            set
            {
                oldMonth = value;
                OnPropertyChanged();
            }
        }

        public string Incoming
        {
            get => incoming;
            set
            {
                incoming = value;
                OnPropertyChanged();
            }
        }

        public string Expense
        {
            get => expense;
            set
            {
                expense = value;
                OnPropertyChanged();
            }
        }

        public string Balance
        {
            get => balance;
            set
            {
                balance = value;
                OnPropertyChanged();
            }
        }

        public MonthBalance(long oldMonth, long incoming, long expense, long balance)
        {
            OldMonth = LongToString(oldMonth);
            Incoming = LongToString(incoming);
            Expense = LongToString(expense);
            Balance = LongToString(balance);
        }
    }
}
