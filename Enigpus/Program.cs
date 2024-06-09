using Enigpus.controllers;

namespace Enigpus;

public static class Program
{
    public static void Main(string[] args)
    {
        var inventoryController = new InventoryController();
        inventoryController.Run();
    }
    
}