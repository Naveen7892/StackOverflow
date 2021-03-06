var request = require('request');
const path = require("path");
const express = require("express");
const app = express();
var cors = require('cors')
// const hbs = require("hbs");
var bodyParser = require('body-parser');

const port = process.env.PORT || 3000;

const pathPublic = path.join(__dirname, "public");
const pathView = path.join(__dirname, "templates/views");
app.set("view engine", "hbs");
app.set("views", pathView);

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));

app.use(express.static(pathPublic));
app.use(cors())


app.get("", (req, res) => {
  res.render("home", {
    title: "Currency Converter"
  });  
});


app.post("/currency", (req, res) => {
	
	console.log(req.body);
	 
    const uri = "https://currency-exchange.p.rapidapi.com/exchange?",
    headers={
		'x-rapidapi-host': 'currency-exchange.p.rapidapi.com',
		'x-rapidapi-key': 'b13c4f3d67msh8143a7f1298de7bp1e8586jsn4453f885a4e7'
    }
    const queryObject  = {
        q: 1,
        from: req.body.fromCurrency,
        to: req.body.toCurrency
	};
	
	console.log(queryObject);

    request({
        url:uri,
        qs:queryObject,
        headers: headers
    }, function (error, response, body) {
		if (error) {
			console.log('error:', error); // Print the error if one occurred

		} else if(response && body) {
			console.log('statusCode:', response && response.statusCode); // Print the response status code if a response was received
			res.json({'body': body}); // Print JSON response.
		}
		})
	});

app.listen(port, () => {
console.log("Server is running on port " + port);
});