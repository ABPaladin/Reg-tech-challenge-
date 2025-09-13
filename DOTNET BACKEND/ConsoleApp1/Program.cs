// See https://aka.ms/new-console-template for more information


Console.WriteLine("Hello, World!");

var response = new ShodanResponseDto
{
    vulns = null
};

Console.WriteLine(response?.vulns?.Length == 0);

public class ShodanResponseDto
{
    public string[]? vulns { get; set; }
}
