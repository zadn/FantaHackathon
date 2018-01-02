# FantaHackathon
This is the API for Accident.


### 1. api/Accident (GET)

Get the list of all accident.

#### Example Response
```json
[
    {
        "id": 3,
        "lplate": "vbmmmm",
        "date": "2018-01-01T08:19:49.473",
        "longitude": 64.66,
        "latitude": 34.44,
        "name": "asdfsdf",
        "age": 5,
        "location": "Palayam",
        "description": "````",
        "verified": 0
    }
]
```

### 2. api/Accident (POST)

This endpoint can be used to add an accident.

#### Body
```json

   {
        "Lplate": "vbmmmm",
        "Longitude": 64.66,
        "Latitude": 34.44,
        "Name": "asdfsdf",
        "Age": 5,
        "Location": "Palayam",
        "Description": "````"
    }

```
### 3. api/Accident/{id} (PUT)

This endpoint can be used to add suppports to a particular event.

#### Body
```json

   {   	
        "verified": 1
    }


```
### 4. api/Accident/{id} (DELETE)

This endpoint can be used to delete an accident.
