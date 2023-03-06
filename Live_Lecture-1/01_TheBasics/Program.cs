#region Namngivning av variabler och klasser
/*
    Namngivning av variabler och klasser
    ----------------------------------------------------------------------------------------------
    PascalCase          C#, VB, C, C++              FirstName, LastName, Customer, GetData()
    camelCase           JS, java, C, C++            firstName, lastName, customer, getData()
    snake_case          python                      first_name, last_name, customer, get_data()
    kebab-case          html, css                   firstname, lastname, product-list, get-data

    ALLT SKA SKRIVAS PÅ ENGELSKA, ALDRIG SVENSKA ORD!!!!
    
    publika variabler                   public ConnectionString
    privata variabler                   var connectionString
    klassnamn                           Customer
        konstruktor/constructors        public Customer()
        fält/fields                     private _connectionString
        egenskaper/properties           public FirstName { get; set; }
        metoder/methods                 public void GetData() {}
            parametrar                  string firstName
     
    u, x, i, z, y           undvik att använda detta   
    x                       jag använder mig av x i tillfällen då jag vill förkorta ner texten

    u   => user
    c   => customer
    x   => customer, user, employee, product


    Det finns tillfällen då vi använder detta här är ett exempel. 

    public async Task GetCustomerAsync(Customer customer) 
    {
        return await _context.Customers.FirstOrDefaultAsync(x => x.Email == customer.Email);
    }

    _context.Customers.FirstOrDefaultAsync(x => x.Email == email);
*/
#endregion

#region Access Modifiers
/*
    Access Modifiers
    ------------------------------------------------------------------------------------
    public                  nåbar: i projektet, i andra projekt, inom den egna klassen
    internal                nåbar: i projektet, inom den egna klassen
    private                 nåbar: inom den egna klassen
    protected               nåbar: via arv

    en klass kan bara vara public eller internal
    en metod kan vara public internal private protected
    attribut (fields/Properties) kan vara public internal private protected
*/
#endregion

#region Static vs Dynamic Instance
/* 
    Static vs. Dynamic
    ----------------------------------------------------------------------------
    normalt, vi gör en instans:                     var customer = new Customer();
                                                    customer.FullName();
    
    static, har redan reserverat utrymme (RAM):     Customer.FullName();       
*/
#endregion

#region Design Patterns (MVVM & MVC)
/*  
    MVC (Model View Controller)
    ----------------------------------------------------------------------------------------------
    Model           Representation av ett Objekt
    View            En grafisk HTML sida 
    Controller      Router...

    MVVM (Model View ViewModel)
    ----------------------------------------------------------------------------------------------
    Model           Representation av ett Objekt
    View            En grafisk sida (WPF-window, WPF-page, WPF-frame, HTML)
    ViewModel       Representation av en View 
*/
#endregion

#region Getters & Setters
/*  
    GETTER SETTER
    -------------------------------------------------------------------------------------------------------
    GET             läs/read            Jag får hämta/läsa värdet, dvs jag kan använda värdet customer.FirstName;
    SET             skriv/write         Jag får sätta ett värde, dvs jag kan sätta ett namn customer.FirstName = "Hans";
 
    { get; private set; }               Jag kan endast sätta ett värde inuti själva klassen
    { get; }                            Jag kan endast hämta ett redan satt värde
    =>                                  Samma som ovan bara det att det är en förenkling.

    = null!                             
*/
#endregion


/* ------------------------------------------------------------------------------------------------------------------ */


Console.ReadKey();


