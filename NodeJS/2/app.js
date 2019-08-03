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


app.get('/', function(request, response) {
  console.log(request.url + " :: " + request.method);    
  response.sendFile(path.join(__dirname + '/templates/views/login.html'));
});

app.post('/auth', function(request, response) {
  console.log(request.url + " :: " + request.method);
  response.redirect('http://localhost:3000/home');           
});

app.get('/home', function(request, response) {
  console.log(request.url + " :: " + request.method);
  response.sendFile(path.join(__dirname + '/templates/views/dashboard.html'));
  // response.end();
});

app.listen(port, () => {
console.log("Server is running on port " + port);
});