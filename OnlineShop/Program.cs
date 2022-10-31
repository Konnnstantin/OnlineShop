{
    Console.WriteLine("Здравствуйте, для того чтобы сделать заказ, введите информацию о себе.\n");
    User user = new User();
    user.OrderUser();
    Order<Delivery> order = new Order<Delivery>();
    order.DisplayOrderType();
    Console.WriteLine("Выберите способ доставки, (Домой,Точка, Магазин) ");
    ChekDelivery chekDelivery = new ChekDelivery();
    chekDelivery.Chek();
}
abstract class Delivery
{
    protected string Address { get; set; }
    protected int NumberPhone { get; set; }

    public override string ToString()
    {
        return Address;
    }
    public abstract void Display();
}
class HomeDelivery<T> : Delivery
{
    private int TimeDelivery { get; set; }

    public override void Display()
    {
        Console.WriteLine("Введите адрес доставки");
        Address = Console.ReadLine();
        Console.WriteLine("Введите время доставки");
        TimeDelivery = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите свой телефон");
        NumberPhone = int.Parse(Console.ReadLine());
        Console.WriteLine(NumberPhone);
    }
}
class PickPointDelivery : Delivery
{
    public string NameCompany { get; set; }
    private int userdel;

    public override void Display()
    {
        Console.WriteLine("Введите Пункт назначения");
        Address = Console.ReadLine();
        Console.WriteLine("Введите свой телефон");
        NumberPhone = int.Parse(Console.ReadLine());
        Console.WriteLine("Срок хранения до 3 суток");
    }
}
class ShopDelivery<T> : Delivery
{
    Company<string, int> company;
    public override void Display()
    {
        company.NameCompany = "Название компнаии";
        company.AdressCompany = "Адрес";
        company.NumberCompany = 279 - 569;
    }
}
class Order<TDelivery> where TDelivery : Delivery
{

    public int ProductCount { get; set; }
    public string Description { get; set; }
    public int ageUser { get; set; }
    public override string ToString()
    {
        return Description;
    }
    public int ChekType;

    public void DisplayOrderType()
    {
        Console.WriteLine("Введите свой возраст");
        ageUser = int.Parse(Console.ReadLine());
        Console.WriteLine("");
        var LisOrder = new Product(new[]
       {
                new Product("Одежда"), new Product("Продукты"), new Product("Бытовая химия"), new Product("Техника"), new Product("Алкоголь")
            });
        Product product1 = LisOrder[0];
        Product product2 = LisOrder[1];
        Product product3 = LisOrder[2];
        Product product4 = LisOrder[3];
        Product product5 = LisOrder[4];
        Console.WriteLine($"{product1} 0");
        Console.WriteLine($"{product2} 1");
        Console.WriteLine($"{product3} 2");
        Console.WriteLine($"{product4} 3");
        Console.WriteLine($"{product5} 4\n");
        int Chekage = 18;
        if (ageUser < Chekage)
        {
            Console.WriteLine("Введите цифру, чтобы выбрать тип продукта");
            do
            {
                Console.WriteLine("Вам нельзя покупать алкоголь выберите другой товар");
                ChekType = int.Parse(Console.ReadLine());
                if (ChekType == 0)
                {
                    product1.arrCloth();
                }
                else if (ChekType == 1)
                {
                    product2.arrFood();
                }
                else if (ChekType == 2)
                {
                    product2.householdChemicals();
                }
                else if (ChekType == 3)
                {
                    product3.arrTechnic();
                }
                else if (ChekType == 4)
                {
                    product4.alcohol();
                }
                else
                {
                    Console.WriteLine("Нет такого индекса");
                }
            } while (ChekType == 4 || ChekType > 4);
        }
        else
        {
            Console.WriteLine("Можете заказать алкоголь");
            Console.WriteLine("Введите цифру, чтобы выбрать тип продукта");
            ChekType = int.Parse(Console.ReadLine());
            if (ChekType == 0)
            {
                product1.arrCloth();
            }
            else if (ChekType == 1)
            {
                product2.arrFood();
            }
            else if (ChekType == 2)
            {
                product2.householdChemicals();
            }
            else if (ChekType == 3)
            {
                product3.arrTechnic();
            }
            else if (ChekType == 4)
            {
                product4.alcohol();
            }
            else
            {
                Console.WriteLine("Нет такого индекса");
            }
        }
    }
}
class ChekDelivery
{
    string delivery = Console.ReadLine();

    public void Chek()
    {

        if (delivery == "Домой")
        {
            HomeDelivery<Delivery> homeDelivery = new HomeDelivery<Delivery>();
            homeDelivery.Display();
        }
        else if (delivery == "Точка")
        {
            PickPointDelivery pickPointDelivery = new PickPointDelivery();
            pickPointDelivery.Display();
        }
        else if (delivery == "Магазин")
        {

            ShopDelivery<Company<string, int>> shopDelivery = new ShopDelivery<Company<string, int>>();
            shopDelivery.Display();
        }
        else
        {
            Console.WriteLine("Не выбрана доставка");
        }
    }
}
class Product
{
    public string TypeProduct { get; }
    public Product(string typeproduct)
    {
        if (string.IsNullOrWhiteSpace(typeproduct))
        {
            throw new ArgumentNullException("Тип продукта не может быть пустым", nameof(typeproduct));
        }

        TypeProduct = typeproduct;
    }
    public override string ToString()
    {
        return TypeProduct;
    }

    Product[] products;
    public Product(Product[] product) => products = product;
    public Product this[int index]
    {
        get => products[index];
        set => products[index] = value;

    }
    string[] Cloth = { "Рубашка", "Майка", "Шорты" };
    string[] Food = { "Колбаса", "Сыр", "Мясо", "Рыба" };
    string[] HouseholdChemicals = { "Порошок", "Мыло", "Туалетная бумага" };
    string[] Technic = { "Телевизор", "Телефон", "Магнитофон" };
    string[] Alcohol = { "Вино", "Водка", "Виски", "Пиво" };
    public void arrCloth()
    {
        foreach (var i in Cloth)
            Console.WriteLine(i);
    }
    public void arrTechnic()
    {
        foreach (var i in Technic)
            Console.WriteLine(i);
    }
    public void arrFood()
    {
        foreach (var i in Food)
            Console.WriteLine(i);
    }
    public void householdChemicals()
    {
        foreach (var i in HouseholdChemicals)
            Console.WriteLine(i);
    }
    public void alcohol()
    {
        foreach (var i in Alcohol)
            Console.WriteLine(i);
    }
}
public class Company<T, T1>
{
    public T AdressCompany { get; set; }
    public T NameCompany { get; set; }
    public T1 NumberCompany { get; set; }
}
class User
{
    public string nameUser { get; set; }
    private string secondName { get; set; }
    private string numberUser { get; set; }
    private int userchek;
    public void OrderUser()
    {
        do
        {
            Console.WriteLine("Введите свое имя");
            nameUser = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(nameUser) || int.TryParse(nameUser, out userchek));

        do
        {
            Console.WriteLine("Введите свою фамилию");
            secondName = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(secondName) || int.TryParse(secondName, out userchek));

        do
        {
            Console.WriteLine("Введите свой номер телефона");
            numberUser = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(numberUser));
    }
}
