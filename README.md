# FantaHackathon
This is the API for Accident.


### 1. api/Accident (GET)

Get the list of all accidents.

#### Example Response
```json
[
    {
        "id": 3,
        "lplate": "vbmmmm",
        "date": "2018-01-01T08:19:49.473",
        "name": "asdfsdf",
        "age": 5,
        "description": "asdff",
        "verified": 0
    }
]
```

### 2. api/Accident (POST)

This endpoint can be used to add an accident.

#### Body
```json

   {
        "Lplate": "tttttttttt",
        "Date": "2018-01-01T08:19:49.473",
        "Name": "asdfsdf",
        "Age": 5,
        "Description": "asdff",
        "Verified": 0
    }

```
### 3. api/Accident/{id} (PUT)

This endpoint can be used to add suppports to a particular event.

#### Body
```json

   {   	
        "Verified": 1
    }


```
### 4. api/Accident/{id} (DELETE)

This endpoint can be used to delete an accident.
