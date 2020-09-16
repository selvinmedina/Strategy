using Strategy_Pattern_First_Look.Business.Models;

namespace Strategy_Pattern_First_Look.Strategies.SalesTax
{
    public interface ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order);
    }
}
