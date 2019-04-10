using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace UserDefinedException
{
    class TestTemperature
    {
        static void Main(string[] args)
        {
            Temperature temp = new Temperature();
            try
            {
                temp.showTemp();
            }
            catch (TempIsZeroException e)
            {
                Console.WriteLine("TempIsZeroException: {0}", e.Message);
            }
            Console.ReadKey();
        }
    }
}
public class TempIsZeroException : ApplicationException
{
    public TempIsZeroException(string message) : base(message)
    {
    }
}
public class Temperature
{
    int temperature = 0;
    public void showTemp()
    {
        if (temperature == 0)
        {
            throw (new TempIsZeroException("Temperature is Zero,pls check!"));
        }
        else
        {
            Console.WriteLine("Temperature is: {0}", temperature);
        }
    }
}