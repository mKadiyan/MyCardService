using MyCardPluginPluginBase;
using System;

namespace VisaCardPlugin;

public class VisaCard: IMyCardPluginPlugin
{
    public void MakePayment()
    {
        Console.WriteLine("The payment is done by VisaMyCardPlugin");
    }

}
