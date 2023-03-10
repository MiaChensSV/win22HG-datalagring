using _02_EntityFrameworkCore_CodeFirst.Services;

var menu = new MenuService();

while(true)
    await menu.MainMenu();

