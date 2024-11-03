// Créez un jeu de gestion de panier de fruits au marché à l’aide d’un tableau de chaînes de caractères.
// L'utilisateur peut ajouter maximum 5 fruits, les retirer, les afficher et les rechercher.
// Gérez les doublons lors de l’ajout. Permettez à l’utilisateur de quitter le jeu via le menu.

List<string> basket = new List<string>();
string[] fruits = { "Pomme", "Poire", "Banane", "Fraise", "Melon" };

void addFruit()
{
    if (basket.Count < 5)
    {
        Console.WriteLine("Quel fruit voulez-vous ajouter au panier?");
        Console.WriteLine("[1] Pomme | [2] Poire | [3] Banane | [4] Fraise | [5] Melon");
        int choiceFruit = Convert.ToInt32(Console.ReadLine());
        if (choiceFruit < 1 || choiceFruit > 5)
        {
            Console.WriteLine("Choix invalide. Veuillez choisir entre [1] et [5].");
            return;
        }
        
        string selectedFruit = fruits[choiceFruit - 1];

        if (!basket.Contains(selectedFruit))
        {
            basket.Add(selectedFruit);
            Console.WriteLine($"Vous avez ajouté {selectedFruit} au panier.");
        }
        else
        {
            Console.WriteLine($"{selectedFruit} a déjà été ajouté au panier. Veuillez choisir un autre fruit.");
        }
    }
    else
    {
        Console.WriteLine("Votre panier est déjà rempli, vous ne pouvez plus ajouter de fruit.");
        Console.WriteLine("Souhaitez-vous supprimer des fruits de votre panier?");
        Console.WriteLine("[1] OUI | [2] NON");
        int choiceBasket = Convert.ToInt32(Console.ReadLine());
        
        if (choiceBasket == 1)
        {
            removeFruit();
        }
        else if (choiceBasket == 2)
        {
            showBasket();
        }
        else
        {
            Console.WriteLine("Veuillez entrer uniquement [1] ou [2]");
        }
    }
}

void removeFruit()
{
    if (basket.Count > 0)
    {
        Console.WriteLine("Quel fruit voulez-vous retirer du panier?");
        for (int i = 0; i < basket.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {basket[i]}");
        }
        
        int choiceRemove = Convert.ToInt32(Console.ReadLine());

        if (choiceRemove >= 1 && choiceRemove <= basket.Count)
        {
            Console.WriteLine($"{basket[choiceRemove - 1]} a été retiré du panier.");
            basket.RemoveAt(choiceRemove - 1);
        }
    }
    else
    {
        Console.WriteLine("Votre panier est vide.");
    }
}

void showBasket()
{
    if (basket.Count == 0)
    {
        Console.WriteLine("Votre panier est vide.");
    }
    else
    {
        Console.WriteLine("Contenu de votre panier: ");
        for (int i = 0; i < basket.Count; i++)
        {
            Console.WriteLine($"[{i + 1}] {basket[i]}");
        }
    }
}

void searchFruit()
{
    Console.WriteLine("Quel fruit recherchez-vous dans le panier?");
    Console.WriteLine("[1] Pomme | [2] Poire | [3] Banane | [4] Fraise | [5] Melon");
    int choice = Convert.ToInt32(Console.ReadLine());
    if (choice < 1 || choice > 5)
    {
        Console.WriteLine("Choix invalide. Veuillez choisir entre [1] et [5].");
        return;
    }

    string choiceFruit = fruits[choice - 1];
    if (basket.Contains(choiceFruit))
    {
        Console.WriteLine($"{choiceFruit} est présent dans le panier.");
    }
    else
    {
        Console.WriteLine($"{choiceFruit} n'est pas dans le panier.");
    }
}

void menu()
{
    while (true)
    {
        Console.WriteLine("\nQue souhaitez-vous faire?");
        Console.WriteLine("[1] Afficher le panier | [2] Ajouter un fruit | [3] Retirer un fruit | [4] Rechercher un fruit | [5] Quitter");
        int choice = Convert.ToInt32(Console.ReadLine());
        switch (choice)
        {
            case 1:
                showBasket();
                break;
            case 2:
                addFruit();
                break;
            case 3:
                removeFruit();
                break;
            case 4:
                searchFruit();
                break;
            case 5:
                Console.WriteLine("Au revoir !");
                return;
            default:
                Console.WriteLine("Choix invalide. Veuillez réessayer.");
                break;
        }
    }
}

menu();