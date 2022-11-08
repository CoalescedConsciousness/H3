using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webshop.DAL.Models;
using System.Text;

namespace Webshop.Helpers.Serializers
{
    public static class CartSerializer
    {

        public static string ToStorageString(this List<Cart> models)
        {
            StringBuilder builder = new();

            int count = 0;
            foreach (var model in models)
            {

                builder.Append($"{model.Id};;{model.Price};;{model.Name};;{model.Quantity}");

                if (count != models.Count)
                {
                    if (models.Count != 1)
                    {
                        builder.Append(";;;");
                    }
                }

                count++;
            }

            return builder.ToString();
        }

        public static List<Cart> ToCartModels(this string str)
        {

            string[] Segments = str.Split(";;;");

            List<Cart> cart = new();

            foreach (var segment in Segments)
            {
                if (segment.Length != 0)
                {
                    string[] points = segment.Split(";;");
                    Cart model = new();

                    model.Id = Convert.ToInt32(points[0]);
                    model.Price = (float)Convert.ToDouble(points[1]);
                    model.Name = points[2];
                    model.Quantity = Convert.ToInt32(points[3]);

                    cart.Add(model);
                }
            }
            return cart;
        }

    }
}