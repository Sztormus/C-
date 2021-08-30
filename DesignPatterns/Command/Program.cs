using System;
using CommandPattern.Commands;
using CommandPattern.Enums;
using CommandPattern.Helpers;
using CommandPattern.Repositories;

namespace CommandPattern
{
    public static class Program
    {
        public static void Main()
        {
            Signature.Sign("Command Pattern", "Author: Piotr Stefaniak", "Based on Pluralsight course");
            Console.WriteLine();

            var shoppingCartRepository = new ShoppingCartRepository();
            var productsRepository = new ProductsRepository();

            var product = productsRepository.FindBy("SM7B");

            var addToCartCommand = new AddToCartCommand(shoppingCartRepository,
                productsRepository,
                product);

            var increaseQuantityCommand = new ChangeQuantityCommand(
                Operation.Increase,
                shoppingCartRepository,
                productsRepository,
                product);

            var manager = new CommandManager();
            manager.Invoke(addToCartCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);
            manager.Invoke(increaseQuantityCommand);

            PrintCart(shoppingCartRepository);

            manager.Undo();

            PrintCart(shoppingCartRepository);
        }

        private static void PrintCart(ShoppingCartRepository shoppingCartRepository)
        {
            var totalPrice = 0m;
            foreach (var (key, (product, quantity)) in shoppingCartRepository.LineItems)
            {
                var price = product.Price * quantity;

                Console.WriteLine($"{key} " + $"${product.Price} x {quantity} = ${price}");

                totalPrice += price;
            }

            Console.WriteLine($"Total price:\t${totalPrice}");
        }
    }
}