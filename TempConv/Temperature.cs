public class Temperature
{
    public double Celsius { get; set; } = 0;
    public double Fahrenheit { get; set; } = 0;
    public double Kelvin { get; set; } = 0;

    public string TypeOfTemp { get; set; } = "";

    public double Value {get; set;} = 0;

    public Temperature()
    { }

    public void TempConversion()
    {
        //F = C x (9/5) + 32;
        //C = (F-32) / (9/5);
        //K = C + 273.15;
        //K = (F - 32) * 5/9 + 273.15;

        if (TypeOfTemp == "Celsius") 
        {
            this.Fahrenheit = (this.Celsius * 9/5) + 32 ;
            this.Kelvin = this.Celsius + 273.15;

        } else if (TypeOfTemp == "Fahrenheit") 
        {
            this.Celsius= (this.Fahrenheit - 32) * 5/9;
            this.Kelvin = (this.Fahrenheit - 32) * 5/9 + 273.15;

        } else if (TypeOfTemp == "Kelvin")
        {
            this.Celsius = this.Kelvin - 273.15;
            this.Fahrenheit = (this.Kelvin - 273.15) * 9/5 + 32;
        }
    }
} 