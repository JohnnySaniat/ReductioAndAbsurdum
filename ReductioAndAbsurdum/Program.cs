List<Product> products = new List<Product>()
{
    new Product()
    {
        ProductId = 1,
        Name = "Cloak of Disapointment",
        Price = 72.99M,
        Sold = false,
        ProductType = "Apparel",
        MagicRating = 1,
    },
    new Product()
    {
        ProductId = 2,
        Name = "Too Much Hair Serum",
        Price = 99.99M,
        Sold = false,
        ProductType = "Potions",
        MagicRating = 6,
    },
    new Product()
    {
        ProductId = 3,
        Name = "Wolfgang's Fang",
        Price = 129.50M,
        Sold = false,
        ProductType = "Enchanted Objects",
        MagicRating = 9,
    },
    new Product()
    {
        ProductId = 4,
        Name = "Lunkledoor's Wand",
        Price = 999.14M,
        Sold = false,
        ProductType = "Wands",
        MagicRating = 10,
    },
    new Product()
    {
        ProductId = 5,
        Name = "Twinkling Cape of Stars",
        Price = 1000.00M,
        Sold = false,
        ProductType = "Apparel",
        MagicRating = 6,
    },
        new Product()
    {
        ProductId = 6,
        Name = "Goblin Feet Vile",
        Price = 49.99M,
        Sold = true,
        ProductType = "Potions",
        MagicRating = 2,
    },
    new Product()
    {
        ProductId = 7,
        Name = "Vampire's Eyebrow Comb",
        Price = 111.11M,
        Sold = true,
        ProductType = "Enchanted Objects",
        MagicRating = 8,
    },
    new Product()
    {
        ProductId = 8,
        Name = "Devil's Wand",
        Price = 666.00M,
        Sold = true,
        ProductType = "Wands",
        MagicRating = 10,
    },
        new Product()
    {
        ProductId = 9,
        Name = "Gooby's Magical Foot",
        Price = 222.00M,
        Sold = true,
        ProductType = "Enchanted Objects",
        MagicRating = 7,
    },
};

string greeting = @"Welcome to Reductio & Absurdum
Providing high-quality magical supplies to the wizarding community for nearly 1000 years" + Environment.NewLine;

Console.WriteLine(greeting);

ViewShopOptions();

void ViewShopOptions()
{
    string choice = null;
    while (choice != "0")
    {
        Console.WriteLine
        (Environment.NewLine + "Choose an option:\n\n" +
                  "0. Exit\n" +
                  "1. View All Products\n" +
                  "2. Query by Type\n" +
                  "3. Add a Product\n" +
                  "4. Update Product Details\n" +
                  "5. Delete a Product\n\n");
        choice = Console.ReadLine();
        if (choice == "0")
        {
            Console.WriteLine("Thanks for Stopping by!");
            break;
        }
        else if (choice == "1")
        {
            ViewAllProducts();
        }
        else if (choice == "2")
        {
            QueryByType();
        }
        else if (choice == "3")
        {
            AddAProduct();
        }
        else if (choice == "4")
        {
            UpdateProductDetails();
        }
        else if (choice == "5")
        {
            DeleteAProduct();
        }
    }

}

void ViewAllProducts()
{
    decimal totalValue = 0.0M;
    foreach (Product product in products)
    {
        if (!product.Sold)
        {
            totalValue += product.Price;
        }
    }
    Console.WriteLine($"\n\nTotal inventory value: ${totalValue}\n\n");

    Console.WriteLine("Products:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} ");
    }

    Product chosenProduct = null;

    while (chosenProduct == null)
    {
        Console.WriteLine("Please enter a product number: \n\n");
        try
        {
            int response = int.Parse(Console.ReadLine().Trim());
            chosenProduct = products[response - 1];
        }
        catch (FormatException)
        {
            Console.WriteLine("Please type only integers!");
        }
        catch (ArgumentOutOfRangeException)
        {
            Console.WriteLine("Please choose an existing item only!");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            Console.WriteLine("Do Better!");
        }
    }

    Console.WriteLine(Environment.NewLine + @$"You selected: 
{chosenProduct.Name}, which costs ${chosenProduct.Price} dollars.
It {(chosenProduct.Sold ? "is not available." : $"is available and calling your name!")}
Its Magic Rating is {chosenProduct.MagicRating} out of 10");
}

void AddAProduct()
{
    Console.WriteLine("\n\nEnter product details:");

    Console.Write("Product Name: ");
    string productName = Console.ReadLine();

    Console.Write("Product Price: ");
    decimal productPrice;
    while (!decimal.TryParse(Console.ReadLine(), out productPrice))
    {
        Console.WriteLine("Please enter a valid decimal value for the price.");
        Console.Write("Product Price: ");
    }

    Console.WriteLine("Select product type:");
    Console.WriteLine("1. Apparel");
    Console.WriteLine("2. Potions");
    Console.WriteLine("3. Enchanted Objects");
    Console.WriteLine("4. Wands");

    int productTypeChoice;
    while (!int.TryParse(Console.ReadLine(), out productTypeChoice) || productTypeChoice < 1 || productTypeChoice > 4)
    {
        Console.WriteLine("Please enter a valid option (1-4).");
        Console.WriteLine("Select product type:");
    }

    string[] productTypes = { "", "Apparel", "Potions", "Enchanted Objects", "Wands" };
    string selectedProductType = productTypes[productTypeChoice];

    Console.Write("Enter Magic Rating (out of 10): ");
    int magicRating;
    while (!int.TryParse(Console.ReadLine(), out magicRating) || magicRating < 0 || magicRating > 10)
    {
        Console.WriteLine("Please enter a valid integer between 0 and 10.");
        Console.Write("Enter Magic Rating (out of 10): ");
    }

    // Instance
    Product newProduct = new Product
    {
        ProductId = products.Count + 1,
        Name = productName,
        Price = productPrice,
        Sold = false,
        ProductType = selectedProductType,
        MagicRating = magicRating,
    };

    // List Add
    products.Add(newProduct);

    Console.WriteLine("Product added successfully!");
}

void UpdateProductDetails()
{
    Console.WriteLine("\n\nEnter the ID of the product you want to update:\n\n");
    Console.WriteLine("Products:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name}");
    }

    Console.WriteLine();

    int productIdToUpdate;
    while (!int.TryParse(Console.ReadLine(), out productIdToUpdate) || productIdToUpdate < 1 || productIdToUpdate > products.Count)
    {
        Console.WriteLine("Please enter a valid product ID.");
        Console.WriteLine("Enter the ID of the product you want to update:");
    }
    Console.WriteLine();

    Product productToUpdate = products[productIdToUpdate - 1];

    Console.WriteLine("Select the detail to update:");
    Console.WriteLine("1. Product Name");
    Console.WriteLine("2. Product Price");
    Console.WriteLine("3. Product Type");
    Console.WriteLine("4. Magic Rating");
    Console.WriteLine("5. Sold Status");
    Console.WriteLine();

    int updateChoice;
    while (!int.TryParse(Console.ReadLine(), out updateChoice) || updateChoice < 1 || updateChoice > 5)
    {
        Console.WriteLine("Please enter a valid option (1-5).");
        Console.WriteLine("\n\nSelect the detail to update:");
    }

    switch (updateChoice)
    {
        case 1:
            Console.Write("Enter new Product Name: ");
            productToUpdate.Name = Console.ReadLine();
            break;

        case 2:
            while (true)
            {
                Console.Write("Enter new Product Price: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Please enter a valid decimal value for the price.");
                }
                else if (decimal.TryParse(input, out decimal price))
                {
                    productToUpdate.Price = price;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid decimal value for the price.");
                }
            }
            break;

        case 3:
            Console.WriteLine("Available Product Types:");
            Console.WriteLine("1. Apparel");
            Console.WriteLine("2. Potions");
            Console.WriteLine("3. Enchanted Objects");
            Console.WriteLine("4. Wands");

            int productTypeChoice;
            while (!int.TryParse(Console.ReadLine(), out productTypeChoice) || productTypeChoice < 1 || productTypeChoice > 4)
            {
                Console.WriteLine("Please enter a valid option (1-4).");
                Console.WriteLine("Enter the number corresponding to the new Product Type:");
            }

            // Mapping choices
            string[] productTypes = { "", "Apparel", "Potions", "Enchanted Objects", "Wands" };
            productToUpdate.ProductType = productTypes[productTypeChoice];
            break;

        case 4:
            while (true)
            {
                Console.Write("Enter new Magic Rating (out of 10): ");
                if (int.TryParse(Console.ReadLine(), out int magicRatingInput) && magicRatingInput >= 0 && magicRatingInput <= 10)
                {
                    productToUpdate.MagicRating = magicRatingInput;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid integer between 0 and 10.");
                }
            }
            break;

        case 5:
            while (true)
            {
                Console.Write("Is the product sold? (true/false): ");
                string input = Console.ReadLine().Trim().ToLower();

                if (input == "true")
                {
                    productToUpdate.Sold = true;
                    break;
                }
                else if (input == "false")
                {
                    productToUpdate.Sold = false;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid boolean value (true/false).");
                }
            }
            break;
    }

    Console.WriteLine("Product details updated successfully!");
}

void DeleteAProduct()
{
    Console.WriteLine("\n\nEnter the ID of the product you want to delete:");

    for (int i = 0; i < products.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {products[i].Name} ");
    }

    int productIdToDelete;
    while (!int.TryParse(Console.ReadLine(), out productIdToDelete) || productIdToDelete < 1 || productIdToDelete > products.Count)
    {
        Console.WriteLine("Please enter a valid product ID.");
        Console.WriteLine("Enter the ID of the product you want to delete:");
       
        for (int i = 0; i < products.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {products[i].Name} ");
        }
    }

    Product productToDelete = products[productIdToDelete - 1];

    Console.WriteLine($"Are you sure you want to delete the product: {productToDelete.Name}? (yes/no)");

    string confirmation = Console.ReadLine().Trim().ToLower();

    if (confirmation == "yes")
    {
        products.Remove(productToDelete);
        Console.WriteLine("Product deleted successfully!");
    }
    else
    {
        Console.WriteLine("Deletion canceled.");
    }
}

void QueryByType()
{
    {
        string choice = null;
        while (choice != "0")
        {
            Console.WriteLine
            ("\n\nChoose an option:\n\n" +
                      "0. Main Menu\n" +
                      "1. View All Products\n" +
                      "2. Apparel\n" +
                      "3. Potions\n" +
                      "4. Enchanted Objects\n" +
                      "5. Wands\n\n");
            choice = Console.ReadLine();
            if (choice == "0")
            {
                Console.WriteLine("Returning to the Main Menu!\n\n");
                break;
            }
            else if (choice == "1")
            {
                ViewAllProducts();
            }
            else if (choice == "2")
            {
                ViewApparelProducts();
            }
            else if (choice == "3")
            {
                ViewPotionProducts();
            }
            else if (choice == "4")
            {
                ViewEnchantedProducts();
            }
            else if (choice == "5")
            {
                ViewWandProducts();
            }
        }

    }

}

void ViewApparelProducts()
{
    var apparelProducts = products.Where(p => p.ProductType == "Apparel").ToList();

    Console.WriteLine("\n\nApparel Products:");
    foreach (var product in apparelProducts)
    {
        Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price:C}");
    }
}

void ViewPotionProducts()
{
    var potionProducts = products.Where(p => p.ProductType == "Potions").ToList();

    Console.WriteLine("\n\nPotion Products:");
    foreach (var product in potionProducts)
    {
        Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price:C}");
    }
}

void ViewEnchantedProducts()
{
    var enchantedProducts = products.Where(p => p.ProductType == "Enchanted Objects").ToList();

    Console.WriteLine("\n\nEnchanted Products:");
    foreach (var product in enchantedProducts)
    {
        Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price:C}");
    }
}

void ViewWandProducts()
{
    var wandProducts = products.Where(p => p.ProductType == "Wands").ToList();

    Console.WriteLine("\n\nWand Products:");
    foreach (var product in wandProducts)
    {
        Console.WriteLine($"Product ID: {product.ProductId}, Name: {product.Name}, Price: {product.Price:C}");
    }
}