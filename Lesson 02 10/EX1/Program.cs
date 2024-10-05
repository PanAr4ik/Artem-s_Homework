namespace EX1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Income salary = new Income(IncomeType.Salary, 10000);
            Income businessIncome = new Income(IncomeType.Business, 20000);

            float salaryTax = TaxConfig.CalculateTax(salary);
            float businessTax = TaxConfig.CalculateTax(businessIncome);

            Console.WriteLine($"Налог с зарплаты: {salaryTax}");
            Console.WriteLine($"Налог с бизнеса: {businessTax}");
            Console.WriteLine($"Общая сумма налогов: {TaxConfig.GetTotalTaxesCollected()}");
        }
    }

    public enum IncomeType
    {
        Salary,
        Business,
        Investments
    }

    public class Income
    {
        public IncomeType Type { get; }
        public float Amount { get; }

        public Income(IncomeType type, float amount)
        {
            Type = type;
            Amount = amount;
        }
    }

    public static class TaxConfig
    {
        private static float totalTaxesCollected = 0;

        public static float SalaryTaxRate { get; private set; } = 0.13f; 
        public static float BusinessTaxRate { get; private set; } = 0.25f;
        public static float InvestmentTaxRate { get; private set; } = 0.15f;

        public static float CalculateTax(Income income)
        {
            float taxRate = GetTaxRate(income.Type);
            float taxAmount = income.Amount * taxRate;
            totalTaxesCollected += taxAmount;
            return taxAmount;
        }

        private static float GetTaxRate(IncomeType type)
        {
            switch (type)
            {
                case IncomeType.Salary:
                    return SalaryTaxRate;
                case IncomeType.Business:
                    return BusinessTaxRate;
                case IncomeType.Investments:
                    return InvestmentTaxRate;
                default:
                    throw new ArgumentException("Unknown income type");
            }
        }

        public static float GetTotalTaxesCollected()
        {
            return totalTaxesCollected;
        }
    }
}
