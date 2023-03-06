using _02_FileStorage.Services;

var menuService = new MenuService();

menuService.ViewCustomers();
Console.ReadKey();

menuService.CreateCustomer();
Console.ReadKey();

menuService.ViewCustomers();
Console.ReadKey();

