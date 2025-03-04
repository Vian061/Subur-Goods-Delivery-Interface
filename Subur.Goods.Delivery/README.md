# Description
This Project is to  automate finish delivery of goods at [Cartrack](https://www.cartrack.id/id/) delivery module.<br>

# Flow
The flow of the project is as follows:<br>
1. Get the list of delivery orders from the database
1. Send the data to the Subur B2C Service API
1. The data will proceed by the Subur B2C Service API

# Specs

| Option | Value |
| ------ | ----------- |
| API_DOCUMENTATION | https://fleetapi-id.cartrack.com/rest/redoc.php |
| API_BASE_URL | https://fleetapi-id.cartrack.com |
| AUTH_KEY | MITR00020:e0426cc2d39696c7e679deab4a27297bddf23a8b639834dfb7501831262fc70e |
| AUTH_TYPE | basic |

notes: <br>
> You need to encode the auth key to Base64 before you send the request to the API.