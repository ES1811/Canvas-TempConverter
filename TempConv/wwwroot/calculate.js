function ConvertButton() {
    //because I'm using <select> and <option>, I need to ensure the first latter from frontend matches backend
    //for example "celsius" is lowercase C, but backend has it in uppercase "Celsius"
    //otherwise I'll keep getting 400 bad request
    //const typeOfTemps = document.getElementById("temptype").value.charAt(0).toUpperCase() + document.getElementById("temptype").value.slice(1);

    const typeOfTemps = document.getElementById("temptype").value; //this works because I needed to fix the values from lowercase to uppercase lol
    const userInput = parseFloat(document.getElementById("userinput").value);

    console.log(typeOfTemps, userInput); //check if elements above are caught properly

    const temps = {
        TypeOfTemp: typeOfTemps,
        Value: userInput,
    }
    console.log(temps) //check to see what it shows

    if (isNaN(userInput)) {
        alert("enter a valid number")
    }

    //unfortunately I have not figure out yet how to do baseURL and make it work regardless of localhost port number
    fetch("http://localhost:5010/tempconverter", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(temps)
    })
        .then((response) => {
            console.log(response.status); //check response for 200 (OK) or 400(bad request)
            if (!response.ok) {
                throw new Error("unable to fetch data");
            }
            return response.json()
        })
        .then((data) => {
            console.log(data); //ensure data is correct

            //round the numbers to 2 decimals
            let roundCelsius = Math.round(data.celsius * 100) / 100;
            let roundFahrenheit = Math.round(data.fahrenheit * 100) / 100;
            let roundKelvin = Math.round(data.kelvin * 100) / 100;

            document.getElementById("result").innerHTML = `
            Celsius: ${roundCelsius}<br>
            Fahrenheit: ${roundFahrenheit}<br>
            Kelvin: ${roundKelvin}`
        })
        .catch((error) => {
            console.error("Error", error);
        })

}