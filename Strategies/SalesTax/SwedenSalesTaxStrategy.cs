﻿using Strategy_Pattern_First_Look.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Strategy_Pattern_First_Look.Strategies.SalesTax
{
    public class SwedenSalesTaxStrategy : ISalesTaxStrategy
    {
        public decimal GetTaxFor(Order order)
        {
            var destination = order.ShippingDetails.DestinationCountry
                .ToLowerInvariant();

            var origin = order.ShippingDetails.OriginCountry
                .ToLowerInvariant();

            #region Tax per item
            if (destination == origin)
            {
                decimal totalTax = 0m;
                foreach (var item in order.LineItems)
                {
                    switch (item.Key.ItemType)
                    {
                        case ItemType.Food:
                            totalTax += (item.Key.Price * 0.06m) * item.Value;
                            break;

                        case ItemType.Literature:
                            totalTax += (item.Key.Price * 0.08m) * item.Value;
                            break;

                        case ItemType.Service:
                        case ItemType.Hardware:
                            totalTax += (item.Key.Price * 0.25m) * item.Value;
                            break;
                    }
                }

                return totalTax;
            }
            #endregion

            return 0;
        }
    }
}
