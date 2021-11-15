using NullObjectPattern.Helpers;
using NullObjectPattern.Repositories;

Signature.Sign("NullObject Pattern", "Author: Piotr Stefaniak", "Based on examples found in the Internet");
Console.WriteLine();

Console.Write("Provide mobile phone name (Samsung, Apple, Sony): ");
var mobilePhoneName = Console.ReadLine();

var mobile = MobileRepository.GetMobileByName(mobilePhoneName!);
mobile.TurnOn();
mobile.TurnOff();