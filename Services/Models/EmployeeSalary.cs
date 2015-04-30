
namespace Services.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CurrencyUnit  { get; set; }
        public double LocalCurrencySalary { get; set; }
        public double GbpSalary { get; set; }        
    }
}
